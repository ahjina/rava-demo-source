using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Service.IService;
using Service;
//using Service;
//using Service.Interfaces;

namespace Rava
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            // services.AddDbContext<DataContext>(options => options.UseSqlServer("Data Source=DESKTOP-K2D3HBN\\SQLEXPRESS;Initial Catalog=dbDemo;Integrated Security=True;Connect Timeout=30;"));

            services.AddDbContext<DataContext>(options => options.UseSqlServer("Data Source=LAPTOP-IE00MCEL\\KURORYUU;Initial Catalog=dbDemo;Integrated Security=True;Connect Timeout=30;"));

            services.AddScoped<IDataContext, DataContext>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUtitlitiesService, UtitlitiesService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IMasterDataService, MasterDataService>();

            services
                .AddMvc(options =>
                {
                    options.EnableEndpointRouting = false;
                })
                .AddNewtonsoftJson()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                    options.JsonSerializerOptions.WriteIndented = true;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
