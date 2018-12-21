using Microsoft.AspNetCore.Mvc;

namespace NiceShop.Web.Areas.Administration.Controllers
{
    public class ShopsController : BaseAdministrationController
    {
        public IActionResult Add()
        {
            return this.View();
        }
    }
}