<template>
    <div class="timeline-heading">
        <table style="width: 100%">
            <tr>
                <td class="b-message-head__email">От:</td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td class="b-message-head__email">Кому:</td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td class="b-message-head__email">Тема:</td>
                <td colspan="2">
                    <h4 class="timeline-title">{{message.subject}}</h4>
                </td>
            </tr>
        </table>
    </div>
</template>
<script>
    export default {
        name: 'MessageHeading',
        props: {
            message: {}
        }
    }
</script>
<style scoped>

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