using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Portfolio
{
    public class UpdatePortfolioRequestDto
    {
        [Required]
        [Range(0.0001, 1000000000, ErrorMessage = "Shares must be greater than 0")]
        public decimal Shares { get; set; }
        [Required]
        [Range(0.01, 1000000000, ErrorMessage = "Average cost must be greater than 0")]
        public decimal AvgCost { get; set; }
        public DateTime? PurchasedOn { get; set; }
    }
}
