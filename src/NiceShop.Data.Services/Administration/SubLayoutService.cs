using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using NiceShop.AutoMapping;
using NiceShop.Data.Models;
using NiceShop.Data.Repositories.Contracts;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.Data.Services.ServiceConstants;
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

        public IEnumerable<SelectListItem> GetShops()
        {
            var result = this.shopsRepository
                .ReadAll()
                .Select(x => new SelectListItem(x.Name, x.Name))
                .ToList();

            result.Add(new SelectListItem("Всички", "Всички"));

            return result;
        }

        public IEnumerable<SelectListItem> GetCategories()
        {
            var result = this.categoriesRepository
                .ReadAll()
                .Select(x => new SelectListItem(x.Name, x.Name))
                .ToList();

            result.Add(new SelectListItem("Всички", "Всички"));

            return result;
        }

        public IEnumerable<SelectListItem> GetOrderTerms()
        {
            var result = new List<SelectListItem>
            {
                new SelectListItem(SortType.NameAsc, SortType.NameAsc),
                new SelectListItem(SortType.NameDesc, SortType.NameDesc),
                new SelectListItem(SortType.CountAsc, SortType.CountAsc),
                new SelectListItem(SortType.CountDesc, SortType.CountDesc)
            };

            return result;
        }
    }
}