using System.ComponentModel.DataAnnotations.Schema;

namespace NiceShop.Data.Models
{
    public class Product : BaseModel
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal BoughtFor { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SoldFor { get; set; }
    }
}