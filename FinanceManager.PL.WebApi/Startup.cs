using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.Extensions;
using FinanceManager.BLL.Impl;
using FinanceManager.PL.WebApi.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FinanceManager.PL.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "FinanceManager.PL.WebApi", Version = "v1"});
            });
            
            services.AddDalDependencies(Configuration);
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<AccountViewMapper>();
            services.AddTransient<CategoryViewMapper>();
            services.AddTransient<TransactionViewMapper>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinanceManager.PL.WebApi v1");
                    c.RoutePrefix = "swagger";
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}