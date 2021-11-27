using System;
using System.IO;
using FinanceManager.DAL.DB;
using FinanceManager.PL.Managers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;



namespace FinanceManager.PL
{
    public sealed class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
    // public class Program
    // {
    //     // public IConfigurationRoot ConfigurationRoot { get; set; }
    //     // public IConfiguration ConnectionConfiguration { get; set; }
    //     
    //     public static void Main()
    //     {
    //         IConfigurationRoot configuration = (new JsonConfigurationManager("appsettings.json")).ConfigurationRoot;
    //         string connectionString = configuration.GetConnectionString("Postgres");
    //         var optionsBuilder = new DbContextOptionsBuilder<FinanceManagerDbContext>();
    //         DbContextOptions<FinanceManagerDbContext> options = optionsBuilder.UseNpgsql(connectionString).Options;
    //
    //         FinanceManagerDbContext dbContext = new FinanceManagerDbContext(options);
    //         IServiceProvider
    //     }
    // }
    //
    // public class SampleContextFactory : IDesignTimeDbContextFactory<FinanceManagerDbContext>
    // {
    //     public FinanceManagerDbContext CreateDbContext(string[] args)
    //     {
    //         IConfigurationRoot configuration = (new JsonConfigurationManager("appsettings.json")).ConfigurationRoot;
    //         string connectionString = configuration.GetConnectionString("Postgres");
    //         var optionsBuilder = new DbContextOptionsBuilder<FinanceManagerDbContext>();
    //         DbContextOptions<FinanceManagerDbContext> options = optionsBuilder.UseNpgsql(connectionString).Options;
    //         return new FinanceManagerDbContext(options);
    //     }
    // }
}