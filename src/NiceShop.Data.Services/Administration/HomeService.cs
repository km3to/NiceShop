using System.Linq;
using System.Text;
using NiceShop.AutoMapping;
using NiceShop.Data.Models;
using NiceShop.Data.Repositories.Contracts;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.Data.Services.ServiceConstants;
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

        public HomeIndexViewModel GetIndexModel(SubLayoutInputModel inputModel)
        {
            var title = new StringBuilder();

            var products = this.productsRepository
                .ReadAll()
                .To<ProductsDetailsViewModel>();

            // TODO: Const
            if (inputModel.Shop != "Всички")
            {
                products = products.Where(x => x.ShopName == inputModel.Shop);
                title.Append($"Продукти за магазин: \"{inputModel.Shop}\"");
            }
            else
            {
                title.Append("Продукти за всички магазини");
            }

            // TODO: Const
            if (inputModel.Category != "Всички")
            {
                products = products.Where(x => x.CategoryName == inputModel.Category);

                title.Append($" и категория: \"{inputModel.Category}\"");
            }
            else
            {
                title.Append(" и всички категории");
            }

            products = this.SortProducts(products, inputModel.SortTerm);
            title.Append($" сортирани по {inputModel.SortTerm}");

            var viewModel = new HomeIndexViewModel
            {
                Title = title.ToString(),
                ControlPanel = inputModel,
                Products = products.ToList()
            };

            return viewModel;
        }

        private IQueryable<ProductsDetailsViewModel> SortProducts(IQueryable<ProductsDetailsViewModel> products, string sortBy)
        {
            switch (sortBy)
            {
                case SortType.NameAsc:
                    products = products.OrderBy(x => x.Name);
                    break;
                case SortType.NameDesc:
                    products = products.OrderByDescending(x => x.Name);
                    break;
                case SortType.CountAsc:
                    products = products.OrderBy(x => x.Count);
                    break;
                case SortType.CountDesc:
                    products = products.OrderByDescending(x => x.Count);
                    break;
            }

            return products;
        }
    }
}