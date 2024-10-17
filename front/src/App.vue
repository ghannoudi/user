import { createRouter, createWebHistory } from 'vue-router';
import HelloWorld from '../components/HelloWorld.vue';
import HealthCheck from '../components/HealthCheck.vue'; // Import the health check component

const routes = [
  {
    path: '/',
    name: 'Home',
    component: HelloWorld,
  },
  {
    path: '/health',
    name: 'HealthCheck',
    component: HealthCheck, // Add the health check route
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
