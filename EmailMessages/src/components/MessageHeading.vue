<template>
  <div class="timeline-heading">
    <table class="heading-table">
      <tr>
        <td class="msg-desc">
          От:
        </td>
        <td>
          <template v-for="(participant, index) in from">
            <ParticipantHeading v-bind:participant="participant" :message="message"/>
          </template>
        </td>
        <td>
          <div class="fa-pull-right" style="text-align: right">
            <span class="b-message-head__email">{{messageDate}}</span>
          </div>
        </td>
      </tr>
      <tr>
        <td class="msg-desc">Кому:</td>
        <td>
          <template v-for="(participant, index) in to">
            <ParticipantHeading v-bind:participant="participant" v-bind:message="message"/>
          </template>
        </td>
        <td class="fa-pull-right" style="text-align: right">
          <span class="b-message-head__email small">{{timeSince}}</span>
        </td>
      </tr>
      <tr>
        <td colspan="3">
          <div class="divider"></div>
        </td>
      </tr>
      <tr>
        <td class="msg-desc">Тема:</td>
        <td>
          <b class="timeline-title">{{this.message.subject}}</b>
        </td>
        <td>
          <a v-bind:href="replyHref" class="b-message-head__email fa-pull-right" title="Ответить">
            <font-awesome-icon icon="reply" class="message-reply"></font-awesome-icon>
          </a>
        </td>
      </tr>
    </table>
  </div>
</template>
<script>
    import ParticipantHeading from "./ParticipantHeading";

    function dimension(time, type) { // Определяем склонение единицы измерения
        const dimension = {
            'n': ['месяцев', 'месяц', 'месяца', 'месяц'],
            'j': ['дней', 'день', 'дня'],
            'G': ['часов', 'час', 'часа'],
            'i': ['минут', 'минуту', 'минуты'],
            'Y': ['лет', 'год', 'года']
        };
        let n = 0;
        if (time >= 5 && time <= 20)
            n = 0;
        else if (time == 1 || time % 10 == 1)
            n = 1;
        else if ((time <= 4 && time >= 1) || (time % 10 <= 4 && time % 10 >= 1))
            n = 2;
        else
            n = 0;
        return time + ' ' + dimension[type][n] + ' назад';

    }

    export default {
        name: 'MessageHeading',
        components: {ParticipantHeading},
        props: {
            message: {},
        },
        computed: {
            from: function () {
                return this.message.from;
            },
            to: function () {
                return this.message.to;
            },
            subject: function () {
                return this.message.subject;
            },
            date: function () {
                return this.message.date;
            },
            messageDate: function () {
                let date = new Date(this.message.date);
                return date.toLocaleDateString() + " " + date.getHours() + ":" + date.getMinutes();
            },
            replyHref: function () {
                return "mailto:" + this.message.from[0].email + "?subject=" + this.message.subject;
            },
            timeSince: function () { // Определяем количество и тип единицы измерения
                let date = new Date(this.message.date);
                let time = (new Date().getTime() - date.getTime()) / 1000;
                if (time < 60) {
                    return 'меньше минуты назад';
                } else if (time < 3600) {
                    return dimension(Math.floor(time / 60), 'i');
                } else if (time < 86400) {
                    return dimension(Math.floor(time / 3600), 'G');
                } else if (time < 2592000) {
                    return dimension(Math.floor(time / 86400), 'j');
                } else if (time < 31104000) {
                    return dimension(Math.floor(time / 2592000), 'n');
                } else if (time >= 31104000) {
                    return dimension(Math.floor(time / 31104000), 'Y');
                }
            }
        }
    }
</script>
<style scoped>
  .divider {
    display: block;
    width: 100%;
    border-bottom: #A3A3A3 dashed 1px;
    margin-top: 25px;
    margin-bottom: 10px;
  }

  .msg-desc {
    color: #A3A3A3;
    width: 10%;
  }

  .b-message-head__email {
    color: #A3A3A3;
  }

  .small {
    font-size: 80%;
  }

  .message-reply {
    color: #A3A3A3;
    cursor: pointer;
  }

  table.heading-table {
    width: 100%;
  }

  table.heading-table > tr > td {
    vertical-align: top;
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

  .timeline-body > p,
  .timeline-body > ul {
    margin-bottom: 0;
  }

  .timeline-body > p + p {
    margin-top: 5px;
  }
</style>
