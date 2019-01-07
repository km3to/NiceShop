using System.Collections.Generic;

namespace NiceShop.Web.Models.Administration.ViewModels
{
    public class CategoryViewModel
    {
        public string Name { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}