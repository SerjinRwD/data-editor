import Documents from './Tabs/Documents/index.vue';
import Music from './Tabs/Music/index.vue';
import Pictures from './Tabs/Pictures/index.vue';
import Videos from './Tabs/Videos/index.vue';

export default [
    {
        path: 'documents',
        component: Documents
    },
    {
        path: 'music',
        component: Music
    },
    {
        path: 'pictures',
        component: Pictures
    },
    {
        path: 'videos',
        component: Videos
    }
];