using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ЛабРаб7
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //установка консоли для вывода лога
            loggerFactory.AddConsole();

            //если приложение в процессе разработки
            if (env.IsDevelopment())
            {
                //то выводим информацию об ошибке, при наличии ошибки
                app.UseDeveloperExceptionPage();
            }

            //обработка запроса - получаем контекст запроса в виде объекта contex 
            //app.Run(async (context) =>
            //{
            //    //отправка ответа в виде строки "Hello World!"
            //    await context.Response.WriteAsync("Hello World!");
            //});
            app.UseStaticFiles();
            app.UseMiddleware<Middleware>();
        }
    }
}
