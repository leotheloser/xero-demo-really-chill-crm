<template>
   <b-container id="app">
    <b-row>
      <b-col>
        <img src="./assets/logo.png">
      </b-col>
    </b-row>
    <b-row>
      <b-col>
        <span>Really Chill CRM</span>
      </b-col>
    </b-row>
    <br>
    <b-row>
      <b-col>
        <NavBar/>
      </b-col>
    </b-row>
    <b-row>
      <b-col>
        <router-view/>
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
import NavBar from '@/components/NavBar';

export default {
  name: 'App',
  components: {
    NavBar,
  },
};
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
