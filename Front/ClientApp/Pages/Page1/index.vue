<template>
    <div class="pin-top">
        <div>
            {{ message }}
        </div>
        <div>
            <Counter text="Clicks" />
        </div>
        <div>
            <button class="button is-primary" @click.passive="onBtnClick" :class="{ 'is-loading': isBusy }">Yo!</button>
        </div>
    </div>
</template>
<script>
    import Counter from '../../Components/Counter.vue';

    export default {
        data: function () {
            return {
                message: 'Hello, Nikki!',
                isBusy: false
            };
        },
        methods: {
            onBtnClick: function () {
                this.isBusy = true;
                alert('Hi there!');
                this.isBusy = false;
            }
        },
        components: {
            Counter: Counter
        }
    };
</script>