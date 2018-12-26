using Microsoft.AspNetCore.Mvc;
using NiceShop.Data.Services.Administration.Contracts;
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

        public IViewComponentResult Invoke()
        {
            var viewModel = new SubLayoutViewModel
            {
                Shops = this.subLayoutService.GetShops(),
                Categories = this.subLayoutService.GetCategories()
            };

            return this.View(viewModel);
        }
    }
}