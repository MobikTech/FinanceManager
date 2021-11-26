using System;
using System.IO;
using FinanceManager.DAL.DB;
using FinanceManager.PL.Managers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FinanceManager.PL
{
    public class Program
    {
        // public IConfigurationRoot ConfigurationRoot { get; set; }
        // public IConfiguration ConnectionConfiguration { get; set; }
        
        public static void Main()
        {
            IConfigurationRoot configuration = (new JsonConfigurationManager("appsettings.json")).ConfigurationRoot;
            string connectionString = configuration.GetConnectionString("Postgres");
            var optionsBuilder = new DbContextOptionsBuilder<FinanceManagerDbContext>();
            DbContextOptions<FinanceManagerDbContext> options = optionsBuilder.UseNpgsql(connectionString).Options;

            FinanceManagerDbContext dbContext = new FinanceManagerDbContext(options);

        }
    }
    
    public class SampleContextFactory : IDesignTimeDbContextFactory<FinanceManagerDbContext>
    {
        public FinanceManagerDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = (new JsonConfigurationManager("appsettings.json")).ConfigurationRoot;
            string connectionString = configuration.GetConnectionString("Postgres");
            var optionsBuilder = new DbContextOptionsBuilder<FinanceManagerDbContext>();
            DbContextOptions<FinanceManagerDbContext> options = optionsBuilder.UseNpgsql(connectionString).Options;
            return new FinanceManagerDbContext(options);
        }
    }
}