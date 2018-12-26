using System.Linq;
using NiceShop.AutoMapping;
using NiceShop.Data.Models;
using NiceShop.Data.Repositories.Contracts;
using NiceShop.Data.Services.Administration.Contracts;
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

        public IndexViewModel GetIndexModel()
        {
            var shops = this.shopsRepository
                .ReadAll()
                .To<IdAndNameViewModel>()
                .ToList();

            var categories = this.categoriesRepository
                .ReadAll()
                .To<IdAndNameViewModel>()
                .ToList();

            var products = this.productsRepository
                .ReadAll()
                .To<DetailsProductViewModel>()
                .ToList();

            var viewModel = new IndexViewModel
            {
                Categories = categories,
                Shops = shops,
                Products = products
            };

            return viewModel;
        }

        public IndexViewModel GetIndexModelForShop(string id)
        {
            var shops = this.shopsRepository
                .ReadAll()
                .To<IdAndNameViewModel>()
                .ToList();

            var categories = this.categoriesRepository
                .ReadAll()
                .To<IdAndNameViewModel>()
                .ToList();

            var products = this.productsRepository
                .ReadAll()
                .Where(x => x.ShopId == id)
                .To<DetailsProductViewModel>()
                .ToList();

            var activeShop = this.shopsRepository
                .ReadById(id)
                .To<IdAndNameViewModel>()
                .FirstOrDefault();

            var activeCategory = this.categoriesRepository
                .ReadById(id)
                .To<IdAndNameViewModel>()
                .FirstOrDefault();

            var viewModel = new IndexViewModel
            {
                ActiveCategory = activeCategory?.Name,
                ActiveShop = activeShop?.Name,
                Categories = categories,
                Shops = shops,
                Products = products
            };

            return viewModel;
        }

        public IndexViewModel GetIndexModelForCategory(string id)
        {
            var shops = this.shopsRepository
                .ReadAll()
                .To<IdAndNameViewModel>()
                .ToList();

            var categories = this.categoriesRepository
                .ReadAll()
                .To<IdAndNameViewModel>()
                .ToList();

            var products = this.productsRepository
                .ReadAll()
                .Where(x => x.CategoryId == id)
                .To<DetailsProductViewModel>()
                .ToList();

            var activeShop = this.shopsRepository
                .ReadById(id)
                .To<IdAndNameViewModel>()
                .FirstOrDefault();

            var activeCategory = this.categoriesRepository
                .ReadById(id)
                .To<IdAndNameViewModel>()
                .FirstOrDefault();

            var viewModel = new IndexViewModel
            {
                ActiveShop = activeShop?.Name,
                ActiveCategory = activeCategory?.Name,
                Categories = categories,
                Shops = shops,
                Products = products
            };

            return viewModel;
        }
    }
}