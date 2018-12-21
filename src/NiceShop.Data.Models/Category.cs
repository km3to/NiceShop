﻿using System.Collections.Generic;

namespace NiceShop.Data.Models
{
    public class Category : BaseModel
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        public string Name { get; set; }

        public string ParentCategoryId { get; set; }

        public virtual Category ParentCategory { get; set; }

        public string ChildCategoryId { get; set; }

        public virtual Category ChildCategory { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}