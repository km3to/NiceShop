using System.Collections.Generic;
using System.Linq;
using NiceShop.AutoMapping;
using NiceShop.Data.Models;
using NiceShop.Data.Repositories.Contracts;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.Web.Models.Administration.ViewModels;

namespace NiceShop.Data.Services.Administration
{
    public class SubLayoutService : ISubLayoutService
    {
        private readonly IRepository<Shop> shopsRepository;
        private readonly IRepository<Category> categoriesRepository;

        public SubLayoutService(IRepository<Shop> shopsRepository, IRepository<Category> categoriesRepository)
        {
            this.shopsRepository = shopsRepository;
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<IdAndNameViewModel> GetShops()
        {
            var result = this.shopsRepository
                .ReadAll()
                .To<IdAndNameViewModel>()
                .ToList();

            return result;
        }

        public IEnumerable<IdAndNameViewModel> GetCategories()
        {
            var result = this.categoriesRepository
                .ReadAll()
                .To<IdAndNameViewModel>()
                .ToList();

            return result;
        }
    }
}