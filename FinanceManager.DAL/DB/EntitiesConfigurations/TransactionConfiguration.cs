using FinanceManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.DAL.DB.EntitiesConfigurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(a => a.Id);
            
            builder
                .HasOne(transaction => transaction.Source)
                .WithMany(account => account.TransactionsAsSource)
                .HasForeignKey(transaction => transaction.SourceId); 
           
            builder
                .HasOne(transaction => transaction.Target)
                .WithMany(account => account.TransactionsAsTarget)
                .HasForeignKey(transaction => transaction.TargetId);
            
            builder
                .HasOne(transaction => transaction.Category)
                .WithMany(category => category.Transactions)
                .HasForeignKey(transaction => transaction.CategoryId);
        }
    }
}