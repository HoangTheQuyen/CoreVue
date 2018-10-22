<template>
<product-details :product="product" />
</template>

<script>
import ProductDetails from "../components/product/Details.vue";

export default {
    name: "product",
    data() {
        return {
            product: null
        };
    },
    components: {
        ProductDetails
    },
    mounted() {
        const slug = this.$route.params.slug;
        
        fetch(`/api/products/${slug}`)
            .then(response => {
                return response.json();
            })
            .then(product => {
                this.product = product;
            });
    }
};
</script>
