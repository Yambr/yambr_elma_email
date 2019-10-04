<template>
  <div>
    <a v-bind:href="contactUri" v-if="(contact)">{{name}}</a>
    <a v-bind:href="userUri" v-if="(user)">{{name}}</a>
    <a v-bind:href="mailToUri" class="b-message-head__email small"><{{email}}></a>
  </div>
</template>
<script>
    export default {
        name: 'ParticipantHeading',
        props: {
            participant: {},
            message: {},
        },
        computed: {
            name: function () {
                return this.participant.name;
            },
            user: function () {
                return this.participant.user;
            },
            contact: function () {
                return this.participant.contact;
            },
            email: function () {
                return this.participant.email;
            },
            subject: function () {
                return this.message.subject;
            },
            contactUri: function () {
                return "/CRM/Contact/Details/" + this.contact;
            },
            userUri: function () {
                return "javascript:showUserInfo(" + this.user + ")";
            },
            mailToUri: function () {
                return "mailto:" + this.email + "?subject=" + this.subject;
            }
        }
    }
</script>
<style scoped>
  a {
    color: #3366CC;
    text-decoration: none;
    cursor: pointer;
  }

  a.b-message-head__email {
    color: #A3A3A3;
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
