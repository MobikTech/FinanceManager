namespace FinanceManager.PL.MVC.Models
{
    public sealed class TransactionViewModel
    {
        public string SourceNumber { get; set; }
        
        public string TargetNumber { get; set; }
        
        public decimal Sum { get; set; }
        
        public string CategoryName { get; set; }
    }
}