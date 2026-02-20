using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class FeeRecord
    {
        public int Id { get; set; }
        
        [Required]
        public string StudentName { get; set; } = string.Empty;
        
        [Required]
        public decimal Amount { get; set; }
        
        [Required]
        public string FeeType { get; set; } = string.Empty;
        
        public string PaymentMode { get; set; } = "Cash";
        
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        
        public string? Remarks { get; set; }
    }
}
