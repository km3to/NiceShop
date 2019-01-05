using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Data.Models;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.Web.Models.Administration.InputModels;
using NiceShop.Web.Models.Administration.ViewModels;

namespace NiceShop.Web.Areas.Administration.Controllers
{
    public class CategoriesController : BaseAdministrationController
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult All()
        {
            var viewModel = this.categoryService
                .GetAll()
                .ToList();

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }
            
            await this.categoryService.CreateAsync(inputModel);

            return this.RedirectToAction("All");
        }

        public IActionResult Update(string id)
        {
            var viewModel = this.categoryService.GetById(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(IdAndNameViewModel inputModel)
        {
            await this.categoryService.UpdateAsync(inputModel);

            return this.RedirectToAction("All");
        }

        public IActionResult Delete(string id)
        {
            var viewModel = this.categoryService.GetById(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(IdAndNameViewModel inputModel)
        {
            await this.categoryService.DeleteAsync(inputModel.Id);

            return this.RedirectToAction("All");
        }
    }
}