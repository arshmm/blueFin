using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("Portfolios")]
    public class Portfolio
    {
        public string AppUserId { get; set; } = string.Empty;
        public int StockId { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Shares { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal AvgCost { get; set; }

        public DateTime? PurchasedOn { get; set; }

        public AppUser AppUser { get; set; } = null!;
        public Stock Stock { get; set; } = null!;
    }
}
