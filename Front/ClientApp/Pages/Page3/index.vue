<template>
    <div>
        <div class="tabs">
            <ul>
                <router-link tag="li" active-class="is-active" to="/page3/pictures">
                    <a>
                        <span class="icon is-small"><i class="fas fa-image" aria-hidden="true"></i></span>
                        <span>Pictures</span>
                    </a>
                </router-link>
                <router-link tag="li" active-class="is-active" to="/page3/music">
                    <a>
                        <span class="icon is-small"><i class="fas fa-music" aria-hidden="true"></i></span>
                        <span>Music</span>
                    </a>
                </router-link>
                <router-link tag="li" active-class="is-active" to="/page3/videos">
                    <a>
                        <span class="icon is-small"><i class="fas fa-film" aria-hidden="true"></i></span>
                        <span>Videos</span>
                    </a>
                </router-link>
                <router-link tag="li" active-class="is-active" to="/page3/documents">
                    <a>
                        <span class="icon is-small"><i class="far fa-file-alt" aria-hidden="true"></i></span>
                        <span>Documents</span>
                    </a>
                </router-link>
            </ul>
        </div>
        <div class="container">
            <router-view></router-view>
        </div>
    </div>
</template>
<script>
    export default {

    }
</script>