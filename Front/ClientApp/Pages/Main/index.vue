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
            </div>
        </nav>
        <div class="container">
            <transition name="custom-classes-transition"
                        enter-active-class="animated faster fadeIn"
                        leave-active-class="animated faster fadeOut">
                <router-view></router-view>
            </transition>
        </div>
    </div>
</template>
<script>
    export default {
        data: function () {
            return {
                isBurgerActive: false
            };
        },
        methods: {
            onBurgerClick: function () {
                this.isBurgerActive = !this.isBurgerActive;
            },
            onMenuItemClick: function () {
                this.isBurgerActive = false;
            }
        },
        created: function () {
            const url = settings.apiUrl + '/api/blog/page';
            console.log({ url: url });
            fetch(url).then(response => console.log(response))
        }
    };
</script>