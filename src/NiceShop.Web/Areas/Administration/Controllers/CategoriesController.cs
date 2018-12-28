using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NiceShop.AutoMapping;
using NiceShop.Data.Models;
using NiceShop.Data.Repositories.Contracts;
using NiceShop.Web.Models.Administration.InputModels;
using NiceShop.Web.Models.Administration.ViewModels;

namespace NiceShop.Web.Areas.Administration.Controllers
{
    public class CategoriesController : BaseAdministrationController
    {
        private readonly IRepository<Category> categoriesRepository;

        public CategoriesController(IRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IActionResult Create()
        {
            var categories = this.categoriesRepository
                .ReadAll()
                .To<CategoryDetailsViewModel>()
                .ToList();

            this.ViewData["categories"] = categories;

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var category = new Category { Name = inputModel.Name };

            await this.categoriesRepository.CreateAsync(category);

            return this.RedirectToAction("Create");
        }
    }
}