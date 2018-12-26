using System.Collections.Generic;

namespace NiceShop.Web.Models.Administration.ViewModels
{
    public class SubLayoutViewModel
    {
        public IEnumerable<IdAndNameViewModel> Shops { get; set; }

        public IEnumerable<IdAndNameViewModel> Categories { get; set; }
    }
}