using NiceShop.AutoMapping;
using NiceShop.Data.Models;

namespace NiceShop.Web.Areas.Administration.Models.ViewModels
{
    public class DetailsShopViewModel : IMapFrom<Shop>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }
    }
}