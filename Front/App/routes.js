import Home from './Routes/Home.vue';
import Page1 from './Routes/Page1.vue';
import Page2 from './Routes/Page2.vue';
import Page3 from './Routes/Page3.vue';

export default [
    { path: '/', component: Home },
    { path: '/page1', component: Page1 },
    { path: '/page2', component: Page2 },
    { path: '/page3', component: Page3 }
];