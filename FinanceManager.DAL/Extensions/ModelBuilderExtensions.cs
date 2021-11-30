using FinanceManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagement.DAL.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
                new Account()
                {
                    Id = 1,
                    Number = "12345",
                    Count = 1000
                },
                new Account()
                {
                    Id = 2,
                    Number = "54321",
                    Count = 0
                }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Products"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Salary"
                },
                new Category()
                {
                    Id = 3,
                    Name = "YouTube Premium"
                }
            );
        }
    }
}