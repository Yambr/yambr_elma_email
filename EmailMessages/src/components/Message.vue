<template>
  <li v-bind:class="{'timeline-inverted': incoming}">
    <template v-if="!incoming">
      <div class="timeline-badge success">
        <font-awesome-icon v-if="!incoming" icon="arrow-right"/>
      </div>
    </template>
    <template v-if="incoming">
      <div class="timeline-badge danger">
        <font-awesome-icon v-if="incoming" icon="arrow-left"/>
      </div>
    </template>
    <div class="timeline-panel">
      <MessageHeading v-bind:message="message" v-bind:date="date"/>
      <div class="timeline-body">
        <table style="width: 100%">
          <tr>
            <td class="msg-desc" style="vertical-align: top" v-on:click="swithMessage()">
              <font-awesome-icon icon="chevron-down" class="switcher"
                                 :transform="{ rotate: iconRotate }"></font-awesome-icon>
            </td>
            <td>
              <div v-show="!this.opened" class="fade msg-header" v-html="message.mainHeader"></div>
              <div v-if="this.opened&&fullMessage" v-html="fullMessage.body" class="msg-body"></div>
            </td>
          </tr>
          <tr v-show="this.opened">
            <td class="msg-desc" v-on:click="swithMessage()">
              <font-awesome-icon icon="chevron-up" class="switcher"></font-awesome-icon>
            </td>
          </tr>
        </table>
      </div>
    </div>
  </li>
</template>
<script scoped>
    import MessageHeading from "./MessageHeading";
    import emailMessageApi from "./api/emailMessageApi";

    export default {
        name: 'Message',
        components: {MessageHeading},
        props: {
            message: {}
        },
        data() {
            return {
                opened: false,
                fullMessage: null,
            }
        },
        methods: {
            swithMessage: function () {
                this.opened = !this.opened;
                if (this.opened && !this.fullMessage) {
                    emailMessageApi.loadEmail(this.message.id).then(value => {
                        this.fullMessage = value;
                    }).catch(reason => {
                        console.warn(reason);
                    });
                    ;
                }
            }
        },
        computed: {
            incoming: function () {
                return this.message.direction === 'Incoming';
            },
            date: function () {
                return new Date(this.message.date);
            },
            iconRotate: function () {
                return this.opened ? 0 : 270;
            }
        }
    }
</script>
<style scoped>
  .msg-header{
    color: #2c3e50;
  }
  .msg-desc {
    color: #A3A3A3;
    width: 10%;
  }

  .switcher {
    cursor: pointer;
  }

  .text-muted {
    color: #6c757d !important;
  }

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


  .timeline > li > .timeline-badge {
    color: #fff;
    width: 50px;
    height: 50px;
    line-height: 50px;
    font-size: 1.4em;
    text-align: center;
    position: absolute;
    top: 16px;
    left: 50%;
    margin-left: -25px;
    background-color: #999999;
    z-index: 100;
    border-top-right-radius: 50%;
    border-top-left-radius: 50%;
    border-bottom-right-radius: 50%;
    border-bottom-left-radius: 50%;
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

  .timeline-badge.primary {
    background-color: #2e6da4 !important;
  }

  .timeline-badge.success {
    background-color: #3f903f !important;
  }

  .timeline-badge.warning {
    background-color: #f0ad4e !important;
  }

  .timeline-badge.danger {
    background-color: #d9534f !important;
  }

  .timeline-badge.info {
    background-color: #5bc0de !important;
  }

  .timeline-body {
    margin-top: 5px;
    padding-top: 5px;
  }

  .timeline-body > p,
  .timeline-body > ul {
    margin-bottom: 0;
  }

  .timeline-body > p + p {
    margin-top: 5px;
  }


  .b-message-head__email {
    color: #A3A3A3;
  }
</style>
