using System.Collections.Generic;

namespace NiceShop.Web.Models.Administration.ViewModels
{
    public class ProductViewModel
    {
        public string Name { get; set; }

        public IEnumerable<ItemViewModel> Items { get; set; }
    }
}