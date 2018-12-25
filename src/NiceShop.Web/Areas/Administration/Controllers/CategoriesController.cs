using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NiceShop.AutoMapping;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.Web.Areas.Administration.Models.BindingModels;
using NiceShop.Web.Areas.Administration.Models.ViewModels;

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

            await this.categoriesService.CreateAsync(bindingModel.Name);

            return this.RedirectToAction("Create");
        }
    }
}