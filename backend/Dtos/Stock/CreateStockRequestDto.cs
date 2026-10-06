using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Stock
{
    public class CreateStockRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol cannot be over 10 characters")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(100, ErrorMessage = "Company Name cannot be over 100 characters")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1, 1000000000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.0, 100.0)]
        public decimal? lastDividend { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Industry cannot be over 100 characters")]
        public string Industry { get; set; } = string.Empty;
        [Range(1, long.MaxValue)]
        public long marketCap { get; set; }
    }
}