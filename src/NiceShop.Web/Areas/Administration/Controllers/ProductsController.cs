using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NiceShop.Data.Models;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.Web.Areas.Administration.Models.BindingModels;
using NiceShop.Web.Areas.Administration.Models.ViewModels;

namespace NiceShop.Web.Areas.Administration.Controllers
{
    public class ProductsController : BaseAdministrationController
    {
        private readonly IProductsService productsService;
        private readonly ICategoriesService categoriesService;
        private readonly IShopsService shopsService;
        private readonly IMapper mapper;

        public ProductsController(
            IProductsService productsService, 
            ICategoriesService categoriesService, 
            IShopsService shopsService, 
            IMapper mapper)
        {
            this.productsService = productsService;
            this.categoriesService = categoriesService;
            this.shopsService = shopsService;
            this.mapper = mapper;
        }

        public IActionResult Details(string id)
        {
            var viewModel = this.productsService
                .GetById(id)
                .ProjectTo<DetailsProductViewModel>()
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

            var product = this.mapper.Map<Product>(bindingModel);
            var id = await this.productsService.CreateAsync(product);

            return this.RedirectToAction("Details", new { id });
        }
        
        private IEnumerable<SelectListItem> GetAllCategories()
        {
            var categories = this.categoriesService.GetAll();
            var result = this.mapper.Map<IQueryable<Category>, IEnumerable<SelectListItem>>(categories);

            return result;
        }

        private IEnumerable<SelectListItem> GetAllShops()
        {
            var shops = this.shopsService.GetAll();
            var result = this.mapper.Map<IQueryable<Shop>, IEnumerable<SelectListItem>>(shops);

            return result;
        }
    }
}