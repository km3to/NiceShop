using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.ViewModels.Products;

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
            var viewModel = this.productsService.GetById(id);

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            var allCategories = this.categoriesService
                .GetAll()
                .ToList();

            var allShops = this.shopsService
                .GetAll()
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
                // TODO: Do something
            }

            var id = await this.productsService.CreateAsync(viewModel);

            return this.RedirectToAction("Details", new { id });
        }
    }
}