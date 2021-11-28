using FinanceManager.BLL.Abstraction;
using FinanceManager.BLL.DTO;
using FinanceManager.BLL.Implementation;
using FinanceManager.BLL.Mappers;
using FinanceManager.DAL.Abstraction;
using FinanceManager.DAL.DB;
using FinanceManager.DAL.Entities;
using FinanceManager.DAL.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.PL
{
    public sealed class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
    
        public void ConfigureServices(IServiceCollection services)
        {
            
            
            // DAL
            services.AddDbContext<FinanceManagerDbContext>(options => 
                options.UseNpgsql(Configuration.GetConnectionString("Postgres")));
            
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            
            // BLL
            services.AddTransient<IGeneralMapper<Account, AccountDTO>, AccountMapper>();
            services.AddTransient<IGeneralMapper<Category, CategoryDTO>, CategoryMapper>();
            services.AddTransient<IGeneralMapper<Transaction, TransactionDTO>, TransactionMapper>();
            
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ITransactionService, TransactionService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // if (env.IsDevelopment())
            // {
            //     app.UseDeveloperExceptionPage();
            // }
            // app.UseRouting();
            //
            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapGet("/", async context =>
            //     {
            //         await context.Response.WriteAsync("Hello World!");
            //     });
            // });
        }
        
    }
}