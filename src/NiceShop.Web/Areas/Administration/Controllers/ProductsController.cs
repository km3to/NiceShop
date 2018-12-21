using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.ViewModels.Products;

namespace NiceShop.Web.Areas.Administration.Controllers
{
    public class ProductsController : BaseAdministrationController
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public IActionResult Details(string id)
        {
            var viewModel = this.productsService.GetById(id);

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
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