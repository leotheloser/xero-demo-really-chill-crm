<template>
  <div>
    <b-jumbotron header="Hey, there!" lead="Welcome to Really Chill CRM.">
      <p>Go make yourself useful and create a contact...</p>
      <b-button variant="dark" :to="{name: 'NewContact'}">Create a Contact</b-button>
    </b-jumbotron>
  </div>
</template>

<script>
export default {
  name: 'Home',
};
</script>
