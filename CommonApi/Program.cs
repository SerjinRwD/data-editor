using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DbRepository.Interfaces;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CommonApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            /* *
             * 
             * В строке 1 мы создаем конфиг, в строке 2 создаем новый scope, чтобы получить экзмпляр
             * RepositoryContextFactory (мы же помним, т.к. зарегистрировали его с временем жизни scope -
             * без scope не будет и экземпляра), в строке 3 Метод DBContext.Database.Migrate() накатывает
             * на базу все миграции, которых еще нет в базе. И если это первый вызов, когда базы еще нет,
             * то создает ее. Далее диспозим скоуп, т.к. нам он больше не нужен.
             * 
             * */

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build(); // 1

            using (var scope = host.Services.CreateScope()) //2
            {
                var services = scope.ServiceProvider;

                var factory = services.GetRequiredService<IRepositoryContextFactory>();

                factory.CreateDbContext(config.GetConnectionString("DefaultConnection")).Database.Migrate(); // 3
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
