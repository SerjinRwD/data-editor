using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Front
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                /* *
                 * https://habr.com/en/post/350298/
                 * 
                 * Необходимо поставить пакет "Microsoft.AspNetCore.SpaServices".
                 * 
                 * Здесь мы включаем поддержку webpack, теперь у нас не будет болеть голова за сборку клиентских ресурсов
                 * и нам не нужно будет каждый раз вручную ее запускать, прописывать куда нибудь в PostBuildEvents или
                 * держать открытым окошко консоли с запущенной webpack –watch.
                 * 
                 * Этой строкой мы создаем инстанс webpack-а в памяти, который будет отслеживать изменения в файлах и запускать
                 * инкрементальную сборку.
                 * 
                 * */
                app.UseWebpackDevMiddleware();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                /* *
                 * https://habr.com/en/post/350298/
                 * 
                 * Необходимо поставить пакет "Microsoft.AspNetCore.SpaServices".
                 * 
                 * Здесь мы включаем поддержку клиентского роутинга.
                 * 
                 * В случае vue-router это нужно, если настроить его на работу
                 * в режиме mode: 'history'.
                 * В режиме mode: 'hash' (по дефолту) такой проблемы нет. Но есть
                 * хэш в ссылке (типа https://localhost:44363/#/page1).
                 * 
                 * */
                //routes.MapSpaFallbackRoute("spa-fallback", new { page = "Index" });
            });

            app.Run(async (context) =>
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Not found");
            });
        }
    }
}
