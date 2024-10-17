<template>
    <div>
      <h2>Backend Health Check</h2>
      <p>Backend Health Status: {{ healthStatus }}</p>
      <button @click="checkBackendHealth">Check Backend Health</button>
    </div>
  </template>
  
  <script>
  export default {
    name: 'HealthCheck',
    data() {
      return {
        healthStatus: "Unknown",
      };
    },
    methods: {
      async checkBackendHealth() {
        try {
          const response = await fetch("/health"); // Replace with actual backend URL
          if (response.ok) {
            this.healthStatus = "Backend is healthy!";
          } else {
            this.healthStatus = "Backend is unhealthy!";
          }
        } catch (error) {
          this.healthStatus = "Failed to connect to backend!";
        }
      }
    },
    mounted() {
      // Optionally check health on component mount
      this.checkBackendHealth();
    }
  };
  </script>
  
  <style scoped>
  h2 {
    color: #42b983;
  }
  </style>
  