namespace FinanceManager.PL.WebApi.Models
{
    public sealed class TransactionViewModel
    {
        public int? Id { get; set; }

        public int? SourceId { get; set; }
        
        public int? TargetId { get; set; }
        
        public decimal Sum { get; set; }
        
        public int? CategoryId { get; set; }
    }
}