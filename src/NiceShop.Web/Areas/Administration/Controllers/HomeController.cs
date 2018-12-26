using Microsoft.AspNetCore.Mvc;
using NiceShop.Data.Services.Administration.Contracts;

namespace NiceShop.Web.Areas.Administration.Controllers
{
    public class HomeController : BaseAdministrationController
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        public IActionResult Index()
        {
            var viewModel = this.homeService.GetIndexModel();

            return this.View(viewModel);
        }

        public IActionResult IndexForShop(string id)
        {
            var viewModel = this.homeService.GetIndexModelForShop(id);

            return this.View(viewModel);
        }

        public IActionResult IndexForCategory(string id)
        {
            var viewModel = this.homeService.GetIndexModelForCategory(id);

            return this.View(viewModel);
        }
    }
}