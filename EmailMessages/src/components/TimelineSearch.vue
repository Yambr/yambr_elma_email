<template>
  <div class="search-wrapper">
    <input type="text" v-model="searchstring" v-on:input="search" v-on:keydown.enter.prevent="searchInHistory" placeholder="Поиск в переписке"/>
    <label>Нажмите ввод (enter) для поиска в истории:</label>
  </div>
</template>
<script>
    export default {
        name: 'TimelineSearch',
        props: ['search', 'searchtext', 'searchInHistory'],
        data: function () {
            return {
                searchstring: ''
            }
        },
    }
</script>
<style scoped>

  div .search-wrapper {
    position: relative;
    width: 100%;
  }

  div .search-wrapper label {
    position: absolute;
    font-size: 12px;
    color: rgba(0, 0, 0, 0.5);
    top: 8px;
    left: 12px;
    z-index: -1;
    transition: .15s all ease-in-out;
  }

  div .search-wrapper input {
    padding: 4px 12px;
    color: rgba(0, 0, 0, 0.7);
    border: 1px solid rgba(0, 0, 0, 0.12);
    transition: .15s all ease-in-out;
    background: white;
    width: 400px;
  }

  div .search-wrapper input:focus {
    outline: none;
    transform: scale(1.05);
  }

  div .search-wrapper input:focus + label {
    font-size: 12px;
    transform: translateY(-24px) translateX(-12px);
  }

  div .search-wrapper input::-webkit-input-placeholder {
    font-size: 12px;
    color: rgba(0, 0, 0, 0.5);
    font-weight: 100;
  }

  div .wrapper {
    display: flex;
    max-width: 444px;
    flex-wrap: wrap;
    padding-top: 12px;
  }

  div .hotpink {
    background: hotpink;
  }

  div .green {
    background: green;
  }

  div .box {
    width: 100px;
    height: 100px;
    border: 1px solid rgba(0, 0, 0, 0.12);
  }

</style>
