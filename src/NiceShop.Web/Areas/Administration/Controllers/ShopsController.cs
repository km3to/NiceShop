using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Data.Models;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.Web.Areas.Administration.Models.BindingModels;
using NiceShop.Web.Areas.Administration.Models.ViewModels;

namespace NiceShop.Web.Areas.Administration.Controllers
{
    public class ShopsController : BaseAdministrationController
    {
        private readonly IShopsService shopsService;
        private readonly IMapper mapper;

        public ShopsController(IShopsService shopsService, IMapper mapper)
        {
            this.shopsService = shopsService;
            this.mapper = mapper;
        }

        public IActionResult Details(string id)
        {
            var viewModel = this.shopsService
                .GetById(id)
                .ProjectTo<DetailsShopViewModel>()
                .FirstOrDefault();

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateShopBindingModel bindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(bindingModel);
            }

            var shop = this.mapper.Map<Shop>(bindingModel);
            var id = await this.shopsService.CreateAsync(shop);

            return this.RedirectToAction("Details", new { id });
        }
    }
}