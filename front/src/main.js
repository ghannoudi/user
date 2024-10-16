import { createApp } from 'vue'
import App from './App.vue'
import axios  from 'axios'


axios.defaults.baseURL = "https://back.agreeablewater-7b00b80b.northeurope.azurecontainerapps.io";


createApp(App).mount('#app')
