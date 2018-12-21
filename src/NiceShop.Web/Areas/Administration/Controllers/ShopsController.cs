using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.ViewModels.Shops;

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
            var viewModel = this.shopsService.GetById(id);

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
                // TODO: Do something
            }

            var id = await this.shopsService.CreateAsync(viewModel);

            return this.RedirectToAction("Details", new { id });
        }
    }
}