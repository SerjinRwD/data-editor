<template>
    <div class="field">
        <label class="label" v-if="hasLabel">{{ label }}</label>
        <div class="control has-icons-right">
            <input class="input" :type="type" :placeholder="placeholder" />
            <span class="icon is-small is-right clickable" @click.prevent="onEyeClick">
                <i class="fas" :class="[showPassword ? 'fa-eye' : 'fa-eye-slash']"></i>
            </span>
        </div>
    </div>
</template>
<script>
    /* Поле ввода пароля.
     * При нажатии на "глазик" изменяется режим отображения (тип) ввода:
     * > пароль скрывается за точками (type="password")
     * > пароль отображается как текст (type="text")
     * Режим отображения ввода определяется вычисляемым свойством type
     * Также изменяется иконка "глазика":
     * > открытый глаз ('fa-eye'), когда пароль "открыт"
     * > зачёркнутый глаз ('fa-eye-slash'), когда пароль скрыт
     * Отображаемая иконка выбирается в биндинге :class непосредственно в разметке (см. строка 7) 
     * */
    export default {
        data: function () {
            return {
                showPassword: false
            }
        },
        props: {
            label: String,
            placeholder: String
        },
        computed: {
            hasLabel: function () {
                return !(this.label === null || (this.label !== undefined && this.label.length === 0));
            },
            type: function () {
                return this.showPassword ? 'text' : 'password';
            }
        },
        methods: {
            onEyeClick: function (e) {
                this.showPassword = !this.showPassword;
            }
        }
    }
</script>
<style scoped>
    .clickable {
        pointer-events: initial !important;
    }
</style>