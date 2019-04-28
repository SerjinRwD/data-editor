<template>
    <div class="pin-top">
        <p>The Home Page!</p>

        <div>
            <Counter text="Clicks" />
        </div>
    </div>
</template>
<script>
    import Counter from '../../Components/Counter.vue';

    export default {
        components: {
            Counter: Counter
        }
    };
</script>