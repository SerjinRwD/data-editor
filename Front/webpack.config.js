'use strict';

/*
 Конфиг собран из основных моментов:
 > Общие настройки:
 https://habr.com/en/post/350298/
 > Специально для vue/vue-loader:
 https://vue-loader.vuejs.org/guide/#manual-setup
*/

const VueLoaderPlugin = require('vue-loader/lib/plugin');
const webpack = require('webpack');
const path = require('path');

const bundleFolder = "./wwwroot/assets/";
const srcFolder = "./ClientApp/";

module.exports = {
    mode: 'development',
    entry: [
        srcFolder + "main.js"
    ],
    devtool: "source-map",
    output: {
        filename: "bundle.js",
        publicPath: 'assets/',
        path: path.resolve(__dirname, bundleFolder)
    },
    module: {
        rules: [
            {
                test: /\.vue$/,
                loader: 'vue-loader'
            },
            // this will apply to both plain `.js` files
            // AND `<script>` blocks in `.vue` files
            /*
            {
                test: /\.js$/,
                loader: 'babel-loader'
            },
            */
            // this will apply to both plain `.css` files
            // AND `<style>` blocks in `.vue` files
            {
                test: /\.css$/,
                use: [
                    'vue-style-loader',
                    'css-loader'
                ]
            }
        ]
    },
    plugins: [
        // make sure to include the plugin for the magic
        new VueLoaderPlugin()
    ]
};
