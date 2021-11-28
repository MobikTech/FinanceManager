namespace FinanceManager.PL.MVC.ViewModels
{
    public sealed class TransactionViewModel
    {
        public int Id { get; set; }
        
        public int? SourceId { get; set; }
        
        public int? TargetId { get; set; }
        
        public float Sum { get; set; }
        
        public int? CategoryId { get; set; }
    }
}