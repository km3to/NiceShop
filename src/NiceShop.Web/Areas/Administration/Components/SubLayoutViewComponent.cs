using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.Web.Models.Administration.InputModels;
using NiceShop.Web.Models.Administration.ViewModels;

namespace NiceShop.Web.Areas.Administration.Components
{
    public class SubLayoutViewComponent : ViewComponent
    {
        private readonly ISubLayoutService subLayoutService;

        public SubLayoutViewComponent(ISubLayoutService subLayoutService)
        {
            this.subLayoutService = subLayoutService;
        }

        public IViewComponentResult Invoke(SubLayoutInputModel inputModel)
        {
            var viewModel = new SubLayoutViewModel
            {
                Shop = inputModel.Shop,
                Category = inputModel.Category,
                SortTerm = inputModel.SortTerm,
                SortTerms = this.subLayoutService.GetOrderTerms(),
                Shops = this.subLayoutService.GetShops(),
                Categories = this.subLayoutService.GetCategories()
            };

            return this.View(viewModel);
        }
    }
}