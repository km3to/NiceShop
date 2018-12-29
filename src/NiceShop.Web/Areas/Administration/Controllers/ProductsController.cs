using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NiceShop.Data.Models;
using NiceShop.Data.Repositories.Contracts;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.Web.Models.Administration.InputModels;

namespace NiceShop.Web.Areas.Administration.Controllers
{
    public class ProductsController : BaseAdministrationController
    {
        private readonly IProductsService productsService;
        private readonly IRepository<Category> categoriesRepository;
        private readonly IRepository<Shop> shopsRepository;
        private readonly IMapper mapper;

        public ProductsController(
            IProductsService productsService,
            IRepository<Category> categoriesRepository,
            IRepository<Shop> shopsRepository, 
            IMapper mapper)
        {
            this.productsService = productsService;
            this.categoriesRepository = categoriesRepository;
            this.shopsRepository = shopsRepository;
            this.mapper = mapper;
        }

        public IActionResult Details(string id)
        {
            var viewModel = this.productsService.DetailsFor(id);

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
        public async Task<IActionResult> Create(ProductCreateInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                // TODO: Create a complex model or use constants
                this.ViewData["categories"] = this.GetAllCategories();
                this.ViewData["shops"] = this.GetAllShops();

                return this.View(inputModel);
            }

            var id = await this.productsService.CreateAsync(inputModel);
            await this.productsService.SaveImages(id, inputModel.Images);

            return this.RedirectToAction("Details", new { id });
        }
        
        // TODO: Create ViewComponent for those 2 and remove them from here
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