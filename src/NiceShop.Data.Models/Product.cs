using System.ComponentModel.DataAnnotations.Schema;

namespace NiceShop.Data.Models
{
    public class Product : BaseModel
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int Count { get; set; }

        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string ShopId { get; set; }

        public virtual Shop Shop { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal BoughtFor { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SoldFor { get; set; }
    }
}