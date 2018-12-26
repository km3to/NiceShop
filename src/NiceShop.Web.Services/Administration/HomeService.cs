using System.Linq;
using NiceShop.AutoMapping;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.Web.Models.Administration.ViewModels;
using NiceShop.Web.Services.Administration.Contracts;

namespace NiceShop.Web.Services.Administration
{
    public class HomeService : IHomeService
    {
        private readonly IShopsService shopsService;
        private readonly ICategoriesService categoryService;
        private readonly IProductsService productsService;

        public HomeService(
            IShopsService shopsService, 
            ICategoriesService categoryService, 
            IProductsService productsService)
        {
            this.shopsService = shopsService;
            this.categoryService = categoryService;
            this.productsService = productsService;
        }

        public IndexViewModel GetIndexModel()
        {
            var shops = this.shopsService
                .GetAll()
                .To<IdAndNameViewModel>()
                .ToList();

            var categories = this.categoryService
                .GetAll()
                .To<IdAndNameViewModel>()
                .ToList();

            var products = this.productsService
                .GetAll()
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
            var shops = this.shopsService
                .GetAll()
                .To<IdAndNameViewModel>()
                .ToList();

            var categories = this.categoryService
                .GetAll()
                .To<IdAndNameViewModel>()
                .ToList();

            var products = this.productsService
                .GetAllForShop(id)
                .To<DetailsProductViewModel>()
                .ToList();

            var activeShop = this.shopsService
                .GetById(id)
                .To<IdAndNameViewModel>()
                .FirstOrDefault();

            var activeCategory = this.categoryService
                .GetById(id)
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
            var shops = this.shopsService
                .GetAll()
                .To<IdAndNameViewModel>()
                .ToList();

            var categories = this.categoryService
                .GetAll()
                .To<IdAndNameViewModel>()
                .ToList();

            var products = this.productsService
                .GetAllForCategory(id)
                .To<DetailsProductViewModel>()
                .ToList();

            var activeShop = this.shopsService
                .GetById(id)
                .To<IdAndNameViewModel>()
                .FirstOrDefault();

            var activeCategory = this.categoryService
                .GetById(id)
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