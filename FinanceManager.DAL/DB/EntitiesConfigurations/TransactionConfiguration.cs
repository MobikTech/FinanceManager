using FinanceManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.DAL.DB.EntityConfigurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(a => a.Id);
            
            builder
                .HasOne(t => t.Source)
                .WithMany(a => a.TransactionsAsSource)
                .HasForeignKey(t => t.SourceId); 
           
            builder
                .HasOne(t => t.Target)
                .WithMany(a => a.TransactionsAsTarget)
                .HasForeignKey(t => t.TargetId);
            
            builder
                .HasOne(t => t.Category)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CategoryId);
        }
    }
}