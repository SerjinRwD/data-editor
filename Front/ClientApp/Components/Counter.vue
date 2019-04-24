<template>
    <button class="button is-primary" v-on:click="onClick">
        {{ text }}: {{ counter }}
    </button>
</template>
<script>
    export default {
        data: function () {
            return {
                counter: 0
            };
        },
        props: {
            text: String
        },
        methods: {
            onClick: function () {
                this.counter++;
            }
        }
    };
</script>