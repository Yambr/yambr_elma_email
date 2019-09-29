<template>
  <div class="container" v-if="!chartEnabled">
    <ul class="timeline">
      <template v-for="(message, index) in messages">
        <TimlineDateDivider v-bind:date="getDate(message)" v-if="showDate(message, index)"/>
        <Message v-bind:message="message"/>
      </template>
    </ul>
  </div>
</template>
<script>
    import Message from "./Message";
    import TimlineDateDivider from "./TimlineDateDivider";

    export default {
        name: 'MessagesTimeline',
        components: {TimlineDateDivider, Message},
        props: {
            chartEnabled: {},
            messages: {}
        },
        date() {
            return {
                date: null
            }
        },
        methods: {
            showDate: function (message, index) {
                let messagedate = this.getDate(message);
                let showDate = false;
                if (!this.date) {
                    showDate = true;
                }
                if (this.date && messagedate.getDate() != this.date.getDate()) {
                    showDate = true;
                }
                else if (index === 0){
                    showDate = true;
                }
                this.date = messagedate;
                return showDate;
            },
            getDate: function (message) {
                return new Date(message.date);
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

  .timeline > li > .timeline-panel {
    width: 46%;
    float: left;
    border: 1px solid #d4d4d4;
    border-radius: 2px;
    padding: 20px;
    position: relative;
    -webkit-box-shadow: 0 1px 6px rgba(0, 0, 0, 0.175);
    box-shadow: 0 1px 6px rgba(0, 0, 0, 0.175);
  }

  .timeline > li > .timeline-panel:before {
    position: absolute;
    top: 26px;
    right: -15px;
    display: inline-block;
    border-top: 15px solid transparent;
    border-left: 15px solid #ccc;
    border-right: 0 solid #ccc;
    border-bottom: 15px solid transparent;
    content: " ";
  }

  .timeline > li > .timeline-panel:after {
    position: absolute;
    top: 27px;
    right: -14px;
    display: inline-block;
    border-top: 14px solid transparent;
    border-left: 14px solid #fff;
    border-right: 0 solid #fff;
    border-bottom: 14px solid transparent;
    content: " ";
  }

  .timeline > li.timeline-inverted > .timeline-panel {
    float: right;
  }

  .timeline > li.timeline-inverted > .timeline-panel:before {
    border-left-width: 0;
    border-right-width: 15px;
    left: -15px;
    right: auto;
  }

  .timeline > li.timeline-inverted > .timeline-panel:after {
    border-left-width: 0;
    border-right-width: 14px;
    left: -14px;
    right: auto;
  }

  .timeline-body > p,
  .timeline-body > ul {
    margin-bottom: 0;
  }

  .timeline-body > p + p {
    margin-top: 5px;
  }
</style>
