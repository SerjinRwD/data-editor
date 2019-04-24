<template>
    <transition
        name="custom-classes-transition"
        enter-active-class="animated faster fadeIn"
        leave-active-class="animated faster fadeOut"
    >
        <div class="modal is-active" v-if="isActive">
            <!--  :class="{ 'is-active': isActive }" -->
            <div class="modal-background" @click="onCloseClick"></div>
            <div class="modal-card">
                <header class="modal-card-head">
                    <p class="modal-card-title">{{ title }}</p>
                    <button class="delete" aria-label="close" @click="onCloseClick"></button>
                </header>
                <section class="modal-card-body">
                    <slot></slot>
                </section>
                <footer class="modal-card-foot">
                    <slot name="footer"></slot>
                </footer>
            </div>
        </div>
    </transition>
</template>
<script>
    export default {
        props: {
            title: String,
            isActive: Boolean
        },
        methods: {
            onCloseClick: function () {
                this.$emit('closing');
            }
        }
    }
</script>