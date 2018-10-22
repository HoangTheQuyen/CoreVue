import 'bootstrap/dist/css/bootstrap.min.css';
import Vue from 'vue';
import VueRouter from 'vue-router';

Vue.use(VueRouter);

import Catalogue from "./pages/Catalogue.vue";
import Product from "./pages/Product.vue";

const routes = [
    {
        path:"/products",
        component:Catalogue
    },
    {
        path:"/products/:slug",
        comments:Product
    },
    {
        path:"*",
        redirect: "/products"   
    }
];

new Vue({
    el: '#app-root',
    router: new VueRouter({
        mode: 'history',
        routes: routes
    }),
    render: h => h(require('./components/App.vue'))
});