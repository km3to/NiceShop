using System.Collections.Generic;

namespace NiceShop.Data.Models
{
    public class Shop : BaseModel
    {
        public string Name { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}