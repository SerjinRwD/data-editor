import Vue from 'vue';
import VueRouter from 'vue-router';
import Vuex from 'vuex';
import App from './App.vue';
import routes from './Pages/routes';

Vue.use(VueRouter);
Vue.use(Vuex);

const router = new VueRouter({
    routes: routes
});

new Vue({
    el: '#app',
    router: router,
    render: function (h) {
        return h(App);
    }
});
