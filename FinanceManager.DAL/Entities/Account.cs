using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.DAL.Entities
{
    public sealed class Account
    {
        public int Id { get; set; }
        public string Number { get; set; }
        
        public decimal Count { get; set; }
        
        public ICollection<Transaction> TransactionsAsSource { get; set; }
        
        public ICollection<Transaction> TransactionsAsTarget { get; set; }

    }
}