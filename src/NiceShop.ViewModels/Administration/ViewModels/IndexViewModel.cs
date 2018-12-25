using System.Collections.Generic;

namespace NiceShop.ViewModels.Administration.ViewModels
{
    public class IndexViewModel
    {
        public string ActiveShop { get; set; }

        public string ActiveCategory { get; set; }

        public IEnumerable<IdAndNameViewModel> Shops { get; set; }

        public IEnumerable<IdAndNameViewModel> Categories { get; set; }

        public IEnumerable<DetailsProductViewModel> Products { get; set; }
    }
}