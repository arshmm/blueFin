using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Portfolio
{
    public class CreatePortfolioRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol cannot be over 10 characters")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [Range(0.0001, 1000000000, ErrorMessage = "Shares must be greater than 0")]
        public decimal Shares { get; set; }
        // Leave empty to use the current market price
        [Range(0.01, 1000000000, ErrorMessage = "Average cost must be greater than 0")]
        public decimal? AvgCost { get; set; }
        public DateTime? PurchasedOn { get; set; }
    }
}
