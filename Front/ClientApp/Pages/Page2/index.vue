<template>
    <div class="pin-top">
        <div>PaGe 2 :(</div>
        <div>
            <button class="button is-primary" @click="showModal">Show modal</button>
        </div>
        <bulma-modal :is-active="isModalShown" @closing="hideModal" title="Test modal">
            <p>
                Modal text.
            </p>
            <p>
                Another modal text.
            </p>
            <template #footer>
                <button class="button is-primary">Gooo!</button>
            </template>
        </bulma-modal>
    </div>
</template>
<script>
    import BulmaModal from '../../Components/BulmaModal.vue';
    export default {
        data: function () {
            return {
                isModalShown: false
            }
        },
        methods: {
            showModal: function () {
                this.isModalShown = true;
            },
            hideModal: function () {
                this.isModalShown = false;
            }
        },
        components: {
            BulmaModal
        }
    }
</script>