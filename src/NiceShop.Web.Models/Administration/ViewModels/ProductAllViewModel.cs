using System.Collections.Generic;
using NiceShop.Web.Models.Administration.InputModels;

namespace NiceShop.Web.Models.Administration.ViewModels
{
    public class ProductAllViewModel
    {
        public string Title { get; set; }

        public SubLayoutInputModel ControlPanel { get; set; }

        public IEnumerable<ProductDetailsViewModel> Products { get; set; }
    }
}