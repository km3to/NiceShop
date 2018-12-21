using Microsoft.AspNetCore.Mvc;

namespace NiceShop.Web.Areas.Administration.Controllers
{
    public class HomeController : BaseAdministrationController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}