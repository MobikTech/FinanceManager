using System.ComponentModel.DataAnnotations;

namespace FinanceManager.DAL.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        

        public int? SourceId { get; set; }
        public Account Source { get; set; }
        
        
        public int? TargetId { get; set; }
        public Account Target { get; set; }
        
        
        public float Sum { get; set; }
        
        
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        
    }
}