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

        public IActionResult Index(SubLayoutInputModel inputModel)
        {
            return this.View();
        }
    }
}