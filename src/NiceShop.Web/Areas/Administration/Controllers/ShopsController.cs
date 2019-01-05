using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.Web.Models.Administration.InputModels;
using NiceShop.Web.Models.Administration.ViewModels;

namespace NiceShop.Web.Areas.Administration.Controllers
{
    public class ShopsController : BaseAdministrationController
    {
        private readonly IShopService shopService;

        public ShopsController(IShopService shopService)
        {
            this.shopService = shopService;
        }

        public IActionResult All()
        {
            var viewModel = this.shopService
                .GetAll()
                .ToList();

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShopCreateInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.shopService.CreateAsync(inputModel);

            return this.RedirectToAction("All");
            //return this.RedirectToAction("Details", new { id });
        }

        public IActionResult Update(string id)
        {
            var viewModel = this.shopService.GetById(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(IdAndNameViewModel inputModel)
        {
            await this.shopService.UpdateAsync(inputModel);

            return this.RedirectToAction("All");
        }

        public IActionResult Delete(string id)
        {
            var viewModel = this.shopService.GetDeleteModel(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ShopCategoryDeleteViewModel inputModel)
        {
            if (inputModel.ProductsCount != 0)
            {
                throw new InvalidOperationException("Не можете да изтриете магазин, в който има продукти!");
            }

            await this.shopService.DeleteAsync(inputModel.Id);

            return this.RedirectToAction("All");
        }
    }
}