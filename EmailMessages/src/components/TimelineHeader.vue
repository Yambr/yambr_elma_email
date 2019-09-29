<template>
  <div class="timeline-movement">
    <table style="width: 100%;">
      <tr>
        <td>
          <TimelineSearch :search="search" :searchtext="searchtext"/>
        </td>
        <td>
          <div class="fa-pull-right nav-calendar">
            <a class="nav-link" v-on:click="callLeft()">
              <font-awesome-icon icon="arrow-left" size="2x"></font-awesome-icon>
            </a>
            <a class="nav-link" v-on:click="showChart()">
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
        <td>
          <div class="fa-pull-right nav-calendar">
            <h3>
              {{message}}
            </h3>
          </div>
        </td>
      </tr>
    </table>
  </div>
</template>
<script>
    import TimelineSearch from "./TimelineSearch";
    export default {
        name: 'TimelineHeader',
        components: {TimelineSearch},
        props: {
            count: {},
            value: {},
            callLeft: {},
            callRight: {},
            showChart: {},
            message: {},
            search:{},
            searchtext:''
        }
    }
</script>
<style scoped>
  .small {
    font-size: 80%;
  }

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
  .nav-calendar{
    color: #2c3e50;
  }

  .nav-link:hover {
    opacity: 0.8;
  }
</style>
