import { createApp } from 'vue'
import App from './App.vue'
import axios  from 'axios'


axios.defaults.baseURL = "https://backuser.ambitiousfield-d44c9f05.northeurope.azurecontainerapps.io";


createApp(App).mount('#app')
