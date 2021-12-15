using System;
using FinanceManager.DAL.DB.EntitiesConfigurations;
using FinanceManager.DAL.Entities;
using FinanceManager.DAL.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.DAL.DB
{
    public sealed class FinanceManagerDbContext : DbContext
    {
        public FinanceManagerDbContext(DbContextOptions<FinanceManagerDbContext> options) : base(options)
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.Seed();
            
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}