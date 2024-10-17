<template>
    <div>
      <h1>Hello World</h1>
      <p>API Base URL: {{ apiBaseUrl }}</p>
      <button @click="checkHealth">Check Health</button>
      <p v-if="healthStatus">{{ healthStatus }}</p>
    </div>
  </template>
  
  <script>
  export default {
    name: 'App',
    data() {
      return {
        healthStatus: null,
      };
    },
    computed: {
      apiBaseUrl() {
        return process.env.VUE_APP_BASE_URL; // Accessing the environment variable
      },
    },
    methods: {
      async checkHealth() {
        try {
          const response = await fetch(`${this.apiBaseUrl}health`); // Using the BASE_URL
          if (response.ok) {
            this.healthStatus = 'Backend is running correctly!';
          } else {
            this.healthStatus = 'Backend is not responding!';
          }
        } catch (error) {
          this.healthStatus = 'Error checking health!';
        }
      },
    },
  };
  </script>
  
  <style>
  /* Add your styles here */
  </style>
  