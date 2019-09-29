<template>
  <li class="timeline">
    <div class="timeline-badge primary">
            <span class="timeline-balloon-date-day">
              {{dateOfMonth}}
            </span>
      <span class="timeline-balloon-date-month">{{monthName}}</span>
    </div>
  </li>
</template>
<script scoped>
    const months = "Января,Февраля,Марта,Апреля,Мая,Июня,Июля,Августа,Сентября,Октября,Ноября,Декабря".split(",");
    export default {
        name: 'TimlineDateDivider',
        props: {
            date: {},
            showDate: {}
        },
        computed: {
            dateOfMonth: function () {
                return this.date.getDate();
            },
            monthName: function () {
                return months[this.date.getMonth()];
            }
        }
    }
</script>
<style scoped>
  .timeline {
    list-style: none;
    padding: 20px 0 20px;
    position: relative;
  }

  .timeline:before {
    top: 0;
    bottom: 0;
    position: absolute;
    content: " ";
    width: 3px;
    background-color: #eeeeee;
    left: 50%;
    margin-left: -1.5px;
  }

  .timeline > li {
    margin-bottom: 20px;
    position: relative;
  }

  .timeline > li:before,
  .timeline > li:after {
    content: " ";
    display: table;
  }

  .timeline > li:after {
    clear: both;
  }

  .timeline > li:before,
  .timeline > li:after {
    content: " ";
    display: table;
  }

  .timeline > li:after {
    clear: both;
  }

  .timeline > li > .timeline-badge {
    color: #fff;
    width: 66px;
    height: 66px;
    line-height: 50px;
    font-size: 1.4em;
    text-align: center;
    position: absolute;
    top: -10px;
    left: 50%;
    margin-left: -33px;
    background-color: #999999;
    z-index: 100;
    border-top-right-radius: 50%;
    border-top-left-radius: 50%;
    border-bottom-right-radius: 50%;
    border-bottom-left-radius: 50%;
  }

  .timeline-badge.primary {
    background-color: #2e6da4 !important;
  }

  .timeline-badge span.timeline-balloon-date-day {
    font-size: 1.4em;
    position: relative;
    top: 0px;
    display: block;
  }

  .timeline-badge span.timeline-balloon-date-month {
    font-size: .5em;
    position: relative;
    top: -30px;
    display: block;
  }

  .timeline-body > p,
  .timeline-body > ul {
    margin-bottom: 0;
  }

  .timeline-body > p + p {
    margin-top: 5px;
  }
</style>
