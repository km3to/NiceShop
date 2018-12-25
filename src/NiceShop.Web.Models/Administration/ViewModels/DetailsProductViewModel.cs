using NiceShop.AutoMapping;
using NiceShop.Data.Models;

namespace NiceShop.ViewModels.Administration.ViewModels
{
    public class DetailsProductViewModel : IMapFrom<Product>
    {
        public string Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string ShopName { get; set; }

        public string ImageUrl { get; set; }

        public decimal BoughtFor { get; set; }

        public decimal Price { get; set; }
    }
}