using System.Collections.Generic;
using System.Linq;
using System.Text;
using NiceShop.AutoMapping;
using NiceShop.Data.Models;
using NiceShop.Data.Repositories.Contracts;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.Data.Services.ServiceConstants;
using NiceShop.Web.Models.Administration.Home;
using NiceShop.Web.Models.Administration.InputModels;
using NiceShop.Web.Models.Administration.ViewModels;

namespace NiceShop.Data.Services.Administration
{
    public class HomeService : IHomeService
    {
        private readonly IRepository<Shop> shopsRepository;
        private readonly IRepository<Category> categoriesRepository;
        private readonly IRepository<Product> productsRepository;

        public HomeService(
            IRepository<Shop> shopsRepository,
            IRepository<Category> categoriesRepository,
            IRepository<Product> productsRepository)
        {
            this.shopsRepository = shopsRepository;
            this.categoriesRepository = categoriesRepository;
            this.productsRepository = productsRepository;
        }

        public HomeIndexViewModel GetIndexModel()
        {
            var shops = this.shopsRepository
                .ReadAll()
                .To<IdAndNameViewModel>()
                .ToList();

            var result = new HomeIndexViewModel{Shops = shops};

            return result;
        }

        public HomeManageViewModel GetManageModel(string id)
        {
            var shop = this.shopsRepository
                .ReadById(id)
                .FirstOrDefault();

            var categories = this.categoriesRepository
                .ReadAll()
                .Where(x => x.Shops.Any(y => y.ShopId == id))
                .Select(category => new CategoryViewModel
                {
                    Name = category.Name,
                    Products = category.Products
                        .Select(product => new ProductViewModel
                        {
                            Name = product.Name,
                            Items = product.Items
                                .Select(item => new ItemViewModel
                                {
                                    
                                })
                        })
                })
                .ToList();

            var result = new HomeManageViewModel
            {
                Name = shop.Name,
                Categories = categories,
            };

            return result;
        }
    }
}