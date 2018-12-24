using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NiceShop.AutoMapping;
using NiceShop.Data.Models;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.Web.Areas.Administration.Models;
using NiceShop.Web.Areas.Administration.Models.BindingModels;
using NiceShop.Web.Areas.Administration.Models.ViewModels;

namespace NiceShop.Web.Areas.Administration.Controllers
{
    public class ProductsController : BaseAdministrationController
    {
        private readonly IProductsService productsService;
        private readonly ICategoriesService categoriesService;
        private readonly IShopsService shopsService;

        public ProductsController(
            IProductsService productsService, 
            ICategoriesService categoriesService, 
            IShopsService shopsService)
        {
            this.productsService = productsService;
            this.categoriesService = categoriesService;
            this.shopsService = shopsService;
        }

        public IActionResult Details(string id)
        {
            var viewModel = this.productsService
                .GetById(id)
                .To<DetailsProductViewModel>()
                .FirstOrDefault();

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            // TODO: Create a complex model or use constants
            this.ViewData["categories"] = this.GetAllCategories();
            this.ViewData["shops"] = this.GetAllShops();

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductBindingModel bindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                // TODO: Create a complex model or use constants
                this.ViewData["categories"] = this.GetAllCategories();
                this.ViewData["shops"] = this.GetAllShops();

                return this.View(bindingModel);
            }

            // TODO: Use AutoMapper
            var product = new Product
            {
                Name = bindingModel.Name,
                Code = bindingModel.Code,
                Description = bindingModel.Description,
                BoughtFor = bindingModel.BoughtFor,
                Price = bindingModel.Price,
                ImageUrl = bindingModel.ImageUrl,
                CategoryId = bindingModel.CategoryId,
                ShopId = bindingModel.ShopId,
            };

            var id = await this.productsService.CreateAsync(product);

            return this.RedirectToAction("Details", new { id });
        }

        // TODO: Need to use standard autoMapper to map here...
        private IEnumerable<SelectListItem> GetAllCategories()
        {
            var result = this.categoriesService
                .GetAll()
                .Select(x => new SelectListItem
                {
                    Value = x.Id,
                    Text = x.Name
                })
                .ToList();

            return result;
        }

        // TODO: Need to use standard autoMapper to map here...
        private IEnumerable<SelectListItem> GetAllShops()
        {
            var result = this.shopsService
                .GetAll()
                .Select(x => new SelectListItem
                {
                    Value = x.Id,
                    Text = x.Name
                })
                .ToList();

            return result;
        }
    }
}