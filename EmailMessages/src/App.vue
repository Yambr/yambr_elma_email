<template>
  <div id="app">
    <Timeline :entity_id="entity_id"  :from_date="from" :to_date="to" :type="type" />
  </div>
</template>

<script>
    import Timeline from "./components/Timeline";

    export default {
        name: 'App',
        components: {
            Timeline
        },
        props:[
            'entity_id',
            'type'
        ],
        data() {
            let fromAsDate = new Date(new Date().getFullYear(), new Date().getMonth(), 1);
            let from = +(fromAsDate);
            let to = +(fromAsDate.setMonth(fromAsDate.getMonth() + 1));
            return {
                msg: 'Welcome to Your Vue.js App',
                from: from,
                to: to
            }
        }
    }
</script>

<style scoped>
  #app {
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    color: #2c3e50;
    margin-top: 60px;
  }
</style>
