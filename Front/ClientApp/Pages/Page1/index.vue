<template>
    <div class="pin-top">
        <div>
            {{ message }}
        </div>
        <div>
            Persistent counter:
        </div>
        <div>
            <button type="button" class="button is-primary" @click="onClick">Clicks: {{ persist }}</button>
        </div>
    </div>
</template>
<script>
    import store from '../../store';
    export default {
        data: function () {
            return {
                message: 'Hello, Nikki!',
                isBusy: false
            };
        },
        computed: {
            persist: function () {
                return store.state.count;
            }
        },
        methods: {
            onClick: function () {
                store.commit('INC');
            }
        }
    }
</script>