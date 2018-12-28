using NiceShop.AutoMapping;
using NiceShop.Data.Models;

namespace NiceShop.Web.Models.Administration.ViewModels
{
    public class ShopDetailsViewModel : IMapFrom<Shop>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }
    }
}