namespace FinanceManager.PL.MVC.Models
{
    public sealed class TransactionViewModel
    {
        public int? SourceId { get; set; }
        
        public int? TargetId { get; set; }
        
        public float Sum { get; set; }
        
        public int? CategoryId { get; set; }
    }
}