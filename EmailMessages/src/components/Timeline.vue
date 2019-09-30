<template>
  <div>
    <TimelineHeader :count="count" :call-left="callLeft" :call-right="callRight" :show-chart="showChartClick"
                    v-bind:message="msg" :search="search" v-bind:searchtext="searchtext"
                    :search-in-history="searchInHistory" :search-in-history-mode="searchInHistoryMode" />
    <transition name="fade">
      <div v-show="!chartEnabled">
        <MessagesTimeline :chart-enabled="chartEnabled" v-bind:messages="renderedMesages"/>
      </div>
    </transition>
    <highcharts :constructor-type="'stockChart'" :options="chartOptions" v-show="chartEnabled"></highcharts>
    <infinite-loading @infinite="infiniteHandler" :identifier="from" v-show="hasInSelectedMonth">
      <div slot="no-more">
        <font-awesome-icon icon="check" class="success" size="2x"></font-awesome-icon>
      </div>
      <div slot="no-results">
        <font-awesome-icon icon="check" class="success" size="2x"></font-awesome-icon>
      </div>
    </infinite-loading>
  </div>
</template>

<script>
    import {Chart} from 'highcharts-vue'
    import Highcharts from 'highcharts'
    import stockInit from "highcharts/modules/stock"
    import emailStatApi from "./api/emailStatApi";
    import emailMessageApi from "./api/emailMessageApi";
    import MessagesTimeline from "./MessagesTimeline";
    import TimelineHeader from "./TimelineHeader";
    import InfiniteLoading from 'vue-infinite-loading';

    stockInit(Highcharts)
    const lang = {
        loading: "Loading...",
        months: "Январь,Февраль,Март,Апрель,Май,Июнь,Июль,Август,Сентябрь,Октябрь,Ноябрь,Декабрь".split(","),
        shortMonths: "Янв,Фев,Мар,Апр,Май,Июн,Июл,Авг,Сен,Окт,Ноя,Дек".split(","),
        weekdays: "Воскресенье,Понедельник,Вторник,Среда,Четверг,Пятница,Суббота".split(","),
        decimalPoint: ".",
        numericSymbols: " т.р., млн.р., млрд.р., трлд.р., трлл.р.,E".split(","),
        resetZoom: "Сбросить масштаб",
        resetZoomTitle: "Сбросить масштаб 1:1",
        thousandsSep: " "
    };
    Highcharts.setOptions({
        lang: lang
    });


    export default {
        props: ["entity_id", "from_date", "to_date"],
        name: "Timeline",
        components: {
            TimelineHeader,
            MessagesTimeline,
            highcharts: Chart,
            InfiniteLoading
        },
        data() {
            return {
                chartOptions: this.defaultChartOptions(),
                showChart: null,
                messages: [],
                searchtext: '',
                searchInHistoryMode: false,
                filterCache: {},
                filteredMessages: [],
                from: this.from_date,
                to: this.to_date,
                skip: 0,
                skipSearch:0,
                size: 10,
                count: 0
            }
        },
        computed: {
            chartEnabled: function () {
                if (this.showChart != null) {
                    return this.showChart;
                }
                if (this.count > 0) {
                    return false;
                }
                let b = !!(this.chartOptions.series);
                return b;
            },
            hasInSelectedMonth: function () {
                if (this.showChart) {
                    return false;
                }
                return this.count > 0;
            },
            msg: function () {
                let selectedDate = new Date(this.from);
                return lang.months[selectedDate.getMonth()] + " " + selectedDate.getFullYear();
            },
            renderedMesages: function () {
                if (!!this.searchtext && this.searchtext.length > 2) {
                    return this.filteredMessages;
                } else {
                    return this.messages;
                }
            }
        },
        mounted() {
            emailStatApi.contractorStat(this.entity_id).then(value => {
                let newChartOptions = this.defaultChartOptions();
                newChartOptions.series = {
                    data: value
                };
                this.chartOptions = newChartOptions;
            }).catch(reason => {
                console.warn(reason);
            });
            emailMessageApi.contractorEmail(
                this.entity_id,
                new Date(this.from),
                new Date(this.to),
                this.skip,
                this.size,
            ).then(value => {
                this.messages = value.messages;
                this.from = +(new Date(value.from));
                this.to = +(new Date(value.to));
                this.skip = value.skip;
                this.count = value.count;
            }).catch(reason => {
                console.warn(reason);
            });
        }
        ,
        methods: {
            resetSearch: function () {
                this.filterCache = {}
                this.searchtext = '';
                this.filteredMessages = [];
                this.searchInHistoryMode = false;
                console.log(this.searchInHistoryMode);
            },
            searchInHistory: function (e) {
                this.resetSearch();
                this.searchInHistoryMode = true;
                console.log(this.searchInHistoryMode);
                let searchText = e.target.value.trim().toLowerCase();
                this.searchtext = searchText;
                if (searchText && searchText.length > 2) {
                    this.searchMove(searchText, 0);
                } else {
                    this.resetSearch();
                }
            },
            search: function (e) {
                let searchText = e.target.value.trim().toLowerCase();
                this.searchtext = searchText;
                if (searchText && searchText.length > 2) {
                    if (this.filterCache[searchText]) {
                        this.filteredMessages = this.filterCache[searchText];
                    } else {
                        let filtered = this.messages.filter(message => {
                            return (message.subject && message.subject.toLowerCase().indexOf(searchText) > 0) ||
                                (message.mainHeader && message.mainHeader.toLowerCase().indexOf(searchText) > 0)
                        });
                        this.filterCache[searchText] = filtered;
                        this.filteredMessages = filtered;
                    }
                } else {
                    this.resetSearch();
                }
            },
            infiniteHandler: function ($state) {
                if(this.searchInHistoryMode) {
                    this.searchMove(this.searchtext, this.skipSearch + this.size, $state);
                }
                else{
                    this.move(this.from, this.to, this.skip + this.size, $state);
                }
            },
            showChartClick: function () {
                this.resetSearch();
                this.showChart = !this.chartEnabled;
            },
            openColumn: function (clickEvent) {
                this.resetSearch();
                let from = clickEvent.point.x
                let fromAsDate = new Date(from);
                let to = +(fromAsDate.setMonth(fromAsDate.getMonth() + 1));
                this.move(from, to, 0);
            }
            ,
            callLeft: function () {
                let fromAsDate = new Date(this.from);
                let toAsDate = new Date(this.to);
                let from = +(fromAsDate.setMonth(fromAsDate.getMonth() - 1));
                let to = +(toAsDate.setMonth(toAsDate.getMonth() - 1));
                this.move(from, to, 0);
            }
            ,
            callRight: function () {
                let fromAsDate = new Date(this.from);
                let toAsDate = new Date(this.to);
                let from = +(fromAsDate.setMonth(fromAsDate.getMonth() + 1));
                let to = +(toAsDate.setMonth(toAsDate.getMonth() + 1));
                this.move(from, to, 0);
            }
            ,
            searchMove: function (searchString, skip, $state) {

                emailMessageApi.contractorEmailSearch(
                    this.entity_id,
                    searchString,
                    skip,
                    this.size,
                ).then(value => {
                    if (skip > 0) {
                        this.filteredMessages = this.messages.concat(value.messages);
                    } else {
                        this.filteredMessages = value.messages;
                    }
                    this.skipSearch = value.skip;
                    this.count = value.count;
                    this.showChart = null;
                    if ($state) {
                        if ((this.skipSearch + this.size) < this.count) {
                            $state.loaded();

                        } else {
                            $state.complete();
                        }
                    }
                }).catch(reason => {
                    console.warn(reason);
                });

            },
            move: function (from, to, skip, $state) {
                this.resetSearch();
                emailMessageApi.contractorEmail(
                    this.entity_id,
                    new Date(from),
                    new Date(to),
                    skip,
                    this.size,
                ).then(value => {
                    if (skip > 0) {
                        this.messages = this.messages.concat(value.messages);
                    } else {
                        this.messages = value.messages;
                    }
                    this.from = +(new Date(value.from));
                    this.to = +(new Date(value.to));
                    this.skip = value.skip;
                    this.count = value.count;
                    this.showChart = null;
                    if ($state) {
                        if ((this.skip + this.size) < this.count) {
                            $state.loaded();

                        } else {
                            $state.complete();
                        }
                    }
                }).catch(reason => {
                    console.warn(reason);
                });

            }
            ,
            defaultChartOptions: function () {
                return {
                    chart: {
                        type: 'column',
                        style: {"fontFamily": "Tahoma, Arial, Helvetica, sans-serif"},
                        alignTicks: false
                    },
                    navigator: {
                        enabled: false
                    },
                    scrollbar: {
                        enabled: false
                    },
                    rangeSelector: {
                        enabled: false
                    },
                    title: {
                        text: "Статистика переписки"
                    },
                    plotOptions: {
                        series: {
                            dataLabels: {
                                enabled: true,
                                format: '<span style="font-weight: 500"><b>{point.y}<b/></span>',
                                style: {
                                    fontWeight: 500
                                }
                            },
                            point: {
                                events: {
                                    click: this.openColumn
                                }
                            }
                        }
                    },
                    tooltip: {
                        pointFormat: '<span style="color:{point.color}">{point.money}</span><b>{point.y}</b>'
                    },
                    series: null
                }
            }

        }
    }
</script>

<style scoped>
  .fade-enter-active, .fade-leave-active {
    transition: opacity ease-in .1s;
  }

  .fade-enter, .fade-leave-to /* .fade-leave-active до версии 2.1.8 */
  {
    opacity: 0;
  }

  .small {
    font-size: 80%;
  }

  .success {
    color: #3f903f !important;
  }
</style>
