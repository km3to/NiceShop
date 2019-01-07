using Microsoft.AspNetCore.Mvc;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.Web.Models.Administration.InputModels;
using NiceShop.Web.Models.Administration.ViewModels;

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

        public IActionResult Manage(string id)
        {
            var viewModel = this.homeService.GetManageModel(id);

            return this.View(viewModel);
        }
    }
}