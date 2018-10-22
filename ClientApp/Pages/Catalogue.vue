<template>
<product-list :products="products" />
</template>

<script>
import ProductList from "../components/catalogue/ProductList.vue";

export default {
    name: "catalogue",
    data() {
        return {
            products: []
        };
    },
    components: {
        ProductList
    },
    mounted() {
        fetch("/api/products")
            .then(response => {
                return response.json();
            })
            .then(products => {
                this.products = products;
            });
    }
};
</script>
