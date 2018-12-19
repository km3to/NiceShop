using System.Collections.Generic;

namespace NiceShop.Data.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set; }

        public string ParentCategoryId { get; set; }

        public Category ParentCategory { get; set; }

        public string ChildCategoryId { get; set; }

        public Category ChildCategory { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}