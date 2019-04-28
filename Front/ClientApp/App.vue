<template>
    <div>
        <nav class="navbar is-info is-fixed-top" role="navigation" aria-label="main navigation">
            <div class="navbar-brand">
                <router-link class="navbar-item" active-class="is-active" to="/">
                    <div @click="onMenuItemClick">
                        <span class="icon is-medium">
                            <i class="fas fa-home"></i>
                        </span>
                    </div>
                </router-link>
                <a role="button" class="navbar-burger" :class="{'is-active': isBurgerActive}" @click="onBurgerClick" aria-label="menu" aria-expanded="false">
                    <span aria-hidden="true"></span>
                    <span aria-hidden="true"></span>
                    <span aria-hidden="true"></span>
                </a>
            </div>
            <div class="navbar-menu" :class="{'is-active': isBurgerActive}">
                <div class="navbar-start">
                    <router-link class="navbar-item" active-class="is-active" to="/page1"><div @click="onMenuItemClick">Page 1</div></router-link>
                    <router-link class="navbar-item" active-class="is-active" to="/page2"><div @click="onMenuItemClick">Page 2</div></router-link>
                    <router-link class="navbar-item" active-class="is-active" to="/page3"><div @click="onMenuItemClick">Page 3</div></router-link>
                </div>
                <div class="navbar-end">
                    <a class="navbar-item" @click.prevent="onLogoutClick">
                        <i class="fas fa-power-off"></i>
                    </a>
                </div>
            </div>
        </nav>
        <div class="container">
            <transition name="custom-classes-transition"
                        enter-active-class="animated faster fadeIn"
                        leave-active-class="animated faster fadeOut">
                <router-view></router-view>
            </transition>
        </div>
        <transition name="custom-classes-transition"
                    enter-active-class="animated faster fadeIn"
                    leave-active-class="animated faster fadeOut">
            <div class="auth map-background has-background-link" v-if="isNeedAuth">
                <form class="box auth-form" @submit.prevent="onAuthSubmit">
                    <div class="field has-text-centered">
                        Вход в систему
                    </div>
                    <popper trigger="hover" :options="{placement: 'bottom'}">
                        <div class="popper">
                            Popper Content
                        </div>
                        <div class="field" slot="reference">
                            <label class="label">Логин</label>
                            <div class="control has-icons-right">
                                <input class="input" type="text" />
                                <span class="icon is-small is-right">
                                    <i class="fas fa-user"></i>
                                </span>
                            </div>
                        </div>
                    </popper>
                    <popper trigger="hover" :options="{placement: 'bottom'}">
                        <div class="popper">
                            Popper Content
                        </div>
                        <Password label="Пароль" placeholder="Ваш пароль" slot="reference" />
                    </popper>
                    <div class="field">
                        <label class="label">&nbsp;</label>
                        <div class="control">
                            <button class="button is-fullwidth" type="submit">Войти</button>
                        </div>
                    </div>
                </form>
            </div>
        </transition>
    </div>
</template>
<script>
    import Password from './Components/BulmaPasswordField.vue';
    import Popper from 'vue-popperjs';
    import 'vue-popperjs/dist/vue-popper.min.css';
    export default {
        data: function () {
            return {
                isBurgerActive: false,
                isNeedAuth: true
            };
        },
        methods: {
            onBurgerClick: function () {
                this.isBurgerActive = !this.isBurgerActive;
            },
            onMenuItemClick: function () {
                this.isBurgerActive = false;
            },
            onAuthSubmit: function () {
                this.isNeedAuth = false;
            },
            onLogoutClick: function () {
                this.isNeedAuth = true;
            }
        },
        created: function () {
            const url = settings.apiUrl + '/api/blog/page';
            console.log({ url: url });
            fetch(url).then(response => console.log(response))
        },
        components: {
            Password,
            Popper
        }
    };
</script>
<style scoped>
    .auth {
        position: fixed;
        left: 0px;
        top: 0px;
        z-index: 30;
        width: 100vw;
        height: 100vh;
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
    }

        .auth .auth-form {
            padding: 60px 40px;
            display: flex;
            flex-direction: column;
            justify-content: space-around;
            width: 100%;
            max-width: 400px;
        }

    @media screen and (max-width: 768px) {
        .auth .auth-form {
            height: 100vh;
            max-height: 320px;
        }
    }

    @media screen and (min-width: 769px) {
        .auth .auth-form {
            max-height: 400px;
        }
    }
</style>