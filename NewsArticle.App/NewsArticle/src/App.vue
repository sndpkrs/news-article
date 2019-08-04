<template>
  <div id="app">
    <img src="./assets/logo.png">
    <NewsArticle/>
  </div>
</template>

<script>
import HelloWorld from './components/HelloWorld'
import NewsArticle from './components/NewsArticle'
export default {
  name: 'App',
  components: {
    HelloWorld,
    NewsArticle
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
