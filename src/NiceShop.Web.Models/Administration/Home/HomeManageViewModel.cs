using System.Collections.Generic;
using NiceShop.Web.Models.Administration.ViewModels;

namespace NiceShop.Web.Models.Administration.Home
{
    public class HomeManageViewModel
    {
        public string Name { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}