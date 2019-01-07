using System.Collections.Generic;

namespace NiceShop.Data.Models
{
    public class Shop : BaseModel
    {
        public Shop()
        {
            this.Categories = new HashSet<ShopCategory>();
            this.Products = new HashSet<Product>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public virtual IEnumerable<ShopCategory> Categories { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }


    }
}