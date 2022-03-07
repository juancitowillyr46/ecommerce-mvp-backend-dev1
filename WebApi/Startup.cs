using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using WebApi.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using WebApi.Services;
using WebApi.Services.Interface;
using WebApi.Interfaces;
using WebApi.Customers;

namespace api
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

            // Configuración Db Context (Base de datos)
            services.AddDbContext<AppDbContext> (opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers().AddNewtonsoftJson(s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            // Configuración Interfaces
            services.AddScoped<IUsersRepository, SqlUsersRepository>();
            services.AddScoped<ICategoriesRepository, SqlCategoriesRepository>();
            services.AddScoped<IProductRepository, SqlProductsRepository>();
            services.AddScoped<IShoppingCartsRepository, SqlShoppingCartsRepository>();
            services.AddScoped<IShoppingCartsItemsRepository, SqlShoppingCartsItemsRepository>();
            services.AddScoped<ICustomersRepository, SqlCustomersRepository>();
            services.AddScoped<IOrdersRepository, SqlOrdersRepository>();

            services.AddScoped<IShoppingCartsService, ShoppingCartsService>();
            services.AddScoped<IShoppingCartsItemsService, ShoppingCartsItemsService>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<ICustomersService, CustomersService>();
            services.AddScoped<IOrdersService, OrdersService>();

            // Automapper para DTO
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "api v1"));
            }

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
