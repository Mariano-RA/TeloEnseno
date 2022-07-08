<template>
  <div id="app">
    <headerComp></headerComp>
    <router-view/>
    <footerComp></footerComp>
  </div>
</template>

<style>
body{
    background-image: url(../public/img/23610028.jpg);
    background-size: cover;
}
  
</style>

<script>
import headerComp from "./components/headerComp.vue";
import footerComp from "./components/footerComp.vue";

export default {
  components: {
    headerComp,
    footerComp,
  }
}
</script>