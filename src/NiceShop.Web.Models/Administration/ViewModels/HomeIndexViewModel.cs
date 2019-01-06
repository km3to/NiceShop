using System.Collections.Generic;

namespace NiceShop.Web.Models.Administration.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<IdAndNameViewModel> Shops { get; set; }
    }
}