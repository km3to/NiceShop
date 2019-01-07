using System.Collections.Generic;
using NiceShop.Web.Models.Administration.ViewModels;

namespace NiceShop.Web.Models.Administration.Home
{
    public class HomeIndexViewModel
    {
        public IEnumerable<IdAndNameViewModel> Shops { get; set; }
    }
}