using System;

namespace FinanceManager.BLL.DTO
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        
        public DateTime? Date { get; set; }
        
        public int? SourceId { get; set; }
        
        public int? TargetId { get; set; }
        
        public int? CategoryId { get; set; }
    }
}