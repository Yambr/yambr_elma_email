<template>
    <div class="timeline-movement">
        <table style="width: 100%;">
            <tr>
                <td></td>
                <td>
                    <div class="pull-right">
                        <a class="nav-link" v-on:click="callLeft()">
                            <font-awesome-icon icon="arrow-left" size="2x"></font-awesome-icon>
                        </a>
                        <a class="nav-link" v-on:click="updateValue(showChart)">
                            <font-awesome-icon icon="calendar" size="2x"></font-awesome-icon>
                        </a>
                        <a class="nav-link" v-on:click="callRight()">
                            <font-awesome-icon icon="arrow-right" size="2x"></font-awesome-icon>
                        </a>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="b-message-head__email">
                    <i>
                        Всего: <b>{{count}}</b>
                    </i>
                </td>
                <td></td>
            </tr>
        </table>
    </div>
</template>
<script>
    export default {
        name: 'TimelineHeader',
        props: {
            count: {},
            value: {},
            callLeft: {},
            callRight: {}
        },
        data(){
            return{
                showChart: this.value
            }
        },
        methods: {
            updateValue: function (value) {
                this.showChart = !value;
                this.$emit('input', !value);
            }
        }
    }
</script>
<style>

    .timeline-movement {
        border-bottom: dashed 1px #4997cd;
        position: relative;
    }

    .pull-right {
        float: right !important;
    }

    .b-message-head__email {
        color: #A3A3A3;
    }

    .nav-link {
        cursor: pointer;
    }

    .nav-link:hover {
        opacity: 0.8;
    }
</style>
