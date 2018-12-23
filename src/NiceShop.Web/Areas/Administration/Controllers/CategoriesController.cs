using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.Web.Areas.Administration.Models;

namespace NiceShop.Web.Areas.Administration.Controllers
{
    public class CategoriesController : BaseAdministrationController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult Create()
        {
            var categories = this.categoriesService
                .GetAll()
                .Select(x => x.Name)
                .ToList();

            this.ViewData["categories"] = categories;

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            await this.categoriesService.CreateAsync(viewModel.Name);

            return this.RedirectToAction("Create");
        }
    }
}