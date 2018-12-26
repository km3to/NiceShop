using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NiceShop.AutoMapping;
using NiceShop.Data.Models;
using NiceShop.Data.Repositories.Contracts;
using NiceShop.Web.Areas.Administration.Models.BindingModels;
using NiceShop.Web.Areas.Administration.Models.ViewModels;

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
                .To<DetailsCategoryViewModel>()
                .ToList();

            this.ViewData["categories"] = categories;

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryBindingModel bindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(bindingModel);
            }

            var category = new Category { Name = bindingModel.Name };

            await this.categoriesRepository.CreateAsync(category);

            return this.RedirectToAction("Create");
        }
    }
}