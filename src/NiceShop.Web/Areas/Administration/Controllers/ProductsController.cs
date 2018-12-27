using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NiceShop.AutoMapping;
using NiceShop.Data.Models;
using NiceShop.Data.Repositories.Contracts;
using NiceShop.Web.Areas.Administration.Models.BindingModels;
using NiceShop.Web.Areas.Administration.Models.ViewModels;
using NiceShop.Web.Models.Administration.ViewModels;

namespace NiceShop.Web.Areas.Administration.Controllers
{
    public class ProductsController : BaseAdministrationController
    {
        private readonly IRepository<Product> productsRepository;
        private readonly IRepository<Category> categoriesRepository;
        private readonly IRepository<Shop> shopsRepository;
        private readonly IMapper mapper;

        public ProductsController(
            IRepository<Product> productsRepository,
            IRepository<Category> categoriesRepository,
            IRepository<Shop> shopsRepository, 
            IMapper mapper)
        {
            this.productsRepository = productsRepository;
            this.categoriesRepository = categoriesRepository;
            this.shopsRepository = shopsRepository;
            this.mapper = mapper;
        }

        public IActionResult Details(string id)
        {
            var viewModel = this.productsRepository
                .ReadById(id)
                .To<ProductsDetailsViewModel>()
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
        public async Task<IActionResult> Create(ProductsCreateBindingModel bindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                // TODO: Create a complex model or use constants
                this.ViewData["categories"] = this.GetAllCategories();
                this.ViewData["shops"] = this.GetAllShops();

                return this.View(bindingModel);
            }

            var product = this.mapper.Map<Product>(bindingModel);
            var id = await this.productsRepository.CreateAsync(product);

            return this.RedirectToAction("Details", new { id });
        }
        
        private IEnumerable<SelectListItem> GetAllCategories()
        {
            var categories = this.categoriesRepository.ReadAll();
            var result = this.mapper.Map<IQueryable<Category>, IEnumerable<SelectListItem>>(categories);

            return result;
        }

        private IEnumerable<SelectListItem> GetAllShops()
        {
            var shops = this.shopsRepository.ReadAll();
            var result = this.mapper.Map<IQueryable<Shop>, IEnumerable<SelectListItem>>(shops);

            return result;
        }
    }
}