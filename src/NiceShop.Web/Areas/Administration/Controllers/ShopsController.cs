using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Data.Models;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.Web.Areas.Administration.Models;

namespace NiceShop.Web.Areas.Administration.Controllers
{
    public class ShopsController : BaseAdministrationController
    {
        private readonly IShopsService shopsService;

        public ShopsController(IShopsService shopsService)
        {
            this.shopsService = shopsService;
        }

        public IActionResult Details(string id)
        {
            var shop = this.shopsService.GetById(id);

            // TODO: Use AutoMapper
            var viewModel = new CreateShopViewModel
            {
                Name = shop.Name,
                Description = shop.Description,
                Address = shop.Address,
            };

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateShopViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            // TODO: Use AutoMapper
            var shop = new Shop
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Address = viewModel.Address,
            };

            var id = await this.shopsService.CreateAsync(shop);

            return this.RedirectToAction("Details", new { id });
        }
    }
}