<template>
  <div>
    <TimelineHeader :count="count" :call-left="callLeft" :call-right="callRight" v-model="showChart"/>
    <transition name="fade">
      <div v-show="!chartEnabled">
        <MessagesTimeline :chart-enabled="chartEnabled" :messages="messages"/>
      </div>
    </transition>
    <highcharts :constructor-type="'stockChart'" :options="chartOptions" v-show="chartEnabled"></highcharts>

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

    stockInit(Highcharts)

    Highcharts.setOptions({
        lang: {
            loading: "Loading...",
            months: "Январь,Февраль,Март,Апрель,Май,Июнь,Июль,Август,Сентябрь,Октябрь,Ноябрь,Декабрь".split(","),
            shortMonths: "Янв,Фев,Мар,Апр,Май,Июн,Июл,Авг,Сен,Окт,Ноя,Дек".split(","),
            weekdays: "Воскресенье,Понедельник,Вторник,Среда,Четверг,Пятница,Суббота".split(","),
            decimalPoint: ".",
            numericSymbols: " т.р., млн.р., млрд.р., трлд.р., трлл.р.,E".split(","),
            resetZoom: "Сбросить масштаб",
            resetZoomTitle: "Сбросить масштаб 1:1",
            thousandsSep: " "
        }
    });


    function openColumn(x) {
        console.warn(x);
    }

    function defaultChartOptions() {
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
                            click: function () {
                                openColumn(this.x);
                            }
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

    function hasInCurrentMonth(value) {
        let currentDate = new Date();
        let currYear = currentDate.getFullYear();
        let currMonth = currentDate.getFullYear();
        for (let i = 0; i < value.length; i++) {
            let date = new Date(value[i][0]);
            let year = currentDate.getFullYear();
            let month = currentDate.getFullYear();
            if (year == currYear && month == currMonth) {
                this.hasInCurrentMonth = true;
                break;
            }
        }
    }

    export default {
        props: ["contractor_id"],
        name: "Timeline",
        components: {
            TimelineHeader,
            MessagesTimeline,
            highcharts: Chart
        },
        data() {
            return {
                msg: 'Welcome to Your Vue.js App',
                chartOptions: defaultChartOptions(),
                showChart: null,
                messages: [],
                from: null,
                to: null,
                skip: 0,
                size: 10,
                count: 0,
                hasInCurrentMonth: false,
            }
        },
        computed: {
            chartEnabled: function () {
                if (this.showChart != null) {
                    return this.showChart;
                }
                if (hasInCurrentMonth) {
                    return false;
                }
                let b = !!(this.chartOptions.series);
                return b;
            }
        },
        mounted() {
            emailStatApi.contractorStat(this.contractor_id).then(value => {
                let newChartOptions = defaultChartOptions();
                newChartOptions.series = {
                    data: value
                };
                this.chartOptions = newChartOptions;
                hasInCurrentMonth.call(this, value);
            });
            emailMessageApi.contractorEmail(this.contractor_id).then(value => {
                this.messages = value.messages;
                this.from = value.from;
                this.to = value.to;
                this.skip = value.skip;
                this.size = value.size;
                this.count = value.count;
            });
        },
        methods:{
            callLeft: function () {
                console.log("left")
                this.msg = "left";
            },
            callRight: function () {
                console.log("right")
                this.msg = "right";
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

</style>
