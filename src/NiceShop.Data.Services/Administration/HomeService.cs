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

        public HomeIndexViewModel GetIndexModel()
        {
            var shops = this.shopsRepository
                .ReadAll()
                .To<IdAndNameViewModel>()
                .ToList();

            var result = new HomeIndexViewModel{Shops = shops};

            return result;
        }
    }
}