using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NiceShop.AutoMapping;
using NiceShop.Data.Models;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.Web.Areas.Administration.Models.BindingModels;
using NiceShop.Web.Areas.Administration.Models.ViewModels;

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
            var viewModel = this.shopsService
                .GetById(id)
                .To<DetailsShopViewModel>()
                .FirstOrDefault();

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateShopBindingModel bindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(bindingModel);
            }

            // TODO: Use AutoMapper
            var shop = new Shop
            {
                Name = bindingModel.Name,
                Description = bindingModel.Description,
                Address = bindingModel.Address,
            };

            var id = await this.shopsService.CreateAsync(shop);

            return this.RedirectToAction("Details", new { id });
        }
    }
}