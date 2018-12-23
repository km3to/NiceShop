using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NiceShop.Data.Models;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.Web.Areas.Administration.Models;

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
            var product = this.productsService
                .GetById(id);

            // TODO: Use AutoMapper
            var viewModel = new CreateProductViewModel
            {
                Name = product.Name,
                Code = product.Code,
                Description = product.Description,
                BoughtFor = product.BoughtFor,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                ShopId = product.ShopId,
                CategoryId = product.CategoryId,
            };

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
        public async Task<IActionResult> Create(CreateProductViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                // TODO: Create a complex model or use constants
                this.ViewData["categories"] = this.GetAllCategories();
                this.ViewData["shops"] = this.GetAllShops();

                return this.View(viewModel);
            }

            // TODO: Use AutoMapper
            var product = new Product
            {
                Name = viewModel.Name,
                Code = viewModel.Code,
                Description = viewModel.Description,
                BoughtFor = viewModel.BoughtFor,
                Price = viewModel.Price,
                ImageUrl = viewModel.ImageUrl,
                CategoryId = viewModel.CategoryId,
                ShopId = viewModel.ShopId,
            };

            var id = await this.productsService.CreateAsync(product);

            return this.RedirectToAction("Details", new { id });
        }

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