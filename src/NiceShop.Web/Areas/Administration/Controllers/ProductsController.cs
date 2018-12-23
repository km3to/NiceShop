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
            var allCategories = this.categoriesService
                .GetAll()
                .Select(x => new SelectListItem
                {
                    Value = x.Id,
                    Text = x.Name
                })
                .ToList();

            var allShops = this.shopsService
                .GetAll()
                .Select(x => new SelectListItem
                {
                    Value = x.Id,
                    Text = x.Name
                })
                .ToList();

            // TODO: Create a complex model or use constants
            this.ViewData["categories"] = allCategories;
            this.ViewData["shops"] = allShops;

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                var allCategories = this.categoriesService
                    .GetAll()
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id,
                        Text = x.Name
                    })
                    .ToList();

                var allShops = this.shopsService
                    .GetAll()
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id,
                        Text = x.Name
                    })
                    .ToList();

                // TODO: Create a complex model or use constants
                this.ViewData["categories"] = allCategories;
                this.ViewData["shops"] = allShops;

                return this.View(viewModel);
            }

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
    }
}