SPA на .Net Core

Выжимка основных моментов по фронту из
https://habr.com/en/post/350298/
(в статье пример под react, но он легко адаптируется под vue)

В статье Habr нигде не мелькает dev-зависимость
webpack-dev-middleware

Про JavaScriptServices
https://docs.microsoft.com/en-us/aspnet/core/client-side/spa-services?view=aspnetcore-2.2#server-side-prerendering

Интересный момент - рендеринг компонентов.
https://github.com/vuejs-templates/webpack/issues/215

В общем, вместо Vue.template используется Vue.render
```
new Vue({
    el: '#app',
    render: function (h) {
        return h(App);
    }
});
```
А если очень хочется template, то вместо 'vue' подключать 'vue/dist/vue'

Используемый CSS фреймворк:
https://bulma.io/
Современный и "отзывчивый" на чистом CSS с понятными именами классов. Легко поженить с Vue.