<template>
  <div>
  <HelloWorld />
  <HealthCheck />
</div>
</template>

<script>
import HelloWorld from "./components/HelloWorld.vue";
import HealthCheck from "./components/Health.vue"; 
export default {
  name: 'App',
  components: {
    HelloWorld,
    HealthCheck
  }
}
</script>

<style>

</style>
