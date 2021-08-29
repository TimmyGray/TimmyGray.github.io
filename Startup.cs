using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using RestfulApiVisualCode.DataBaseContext;
using RestfulApiVisualCode.Models;

namespace RestfulApiVisualCode
{
    public class Startup
    {
      /*   public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        } */

     //   public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

             string con = "Server=(localdb)\\mssqllocaldb;Database=warningeventsdbstore;Trusted_Connection=True;";
            // устанавливаем контекст данных
            services.AddDbContext<WarningEventContext>(options => options.UseSqlServer(con));
 
            services.AddControllers(); // используем контроллеры без представлений
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           /*  if (env.IsDevelopment())
            {
              //  app.UseSwagger();
              //  app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestfulApiVisualCode v1"));
            } */
            app.UseDeveloperExceptionPage();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

          //  app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
