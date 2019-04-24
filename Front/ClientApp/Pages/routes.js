import Home from './Home/index.vue';
import Page1 from './Page1/index.vue';
import Page2 from './Page2/index.vue';
import Page3 from './Page3/index.vue';
import Page3Routes from './Page3/routes';

export default [
    {
        path: '/',
        component: Home
    },
    {
        path: '/page1',
        component: Page1
    },
    {
        path: '/page2',
        component: Page2
    },
    {
        path: '/page3',
        component: Page3,
        children: Page3Routes
    }
];