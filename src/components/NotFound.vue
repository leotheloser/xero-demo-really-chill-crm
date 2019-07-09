<template>
  <div>
    <b-jumbotron header="404" lead="Your page ain't here, kid.">
      <b-button variant="secondary" :to="{name: 'Home'}">Go Home</b-button>
    </b-jumbotron>
  </div>
</template>

<script>
export default {
  name: 'NotFound',
};
</script>
