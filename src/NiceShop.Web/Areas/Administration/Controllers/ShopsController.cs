using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NiceShop.AutoMapping;
using NiceShop.Data.Models;
using NiceShop.Data.Repositories.Contracts;
using NiceShop.Web.Models.Administration.InputModels;
using NiceShop.Web.Models.Administration.ViewModels;

namespace NiceShop.Web.Areas.Administration.Controllers
{
    public class ShopsController : BaseAdministrationController
    {
        private readonly IRepository<Shop> shopsRepository;
        private readonly IMapper mapper;

        public ShopsController(IRepository<Shop> shopsRepository, IMapper mapper)
        {
            this.shopsRepository = shopsRepository;
            this.mapper = mapper;
        }

        public IActionResult Details(string id)
        {
            var viewModel = this.shopsRepository
                .ReadById(id)
                .To<ShopDetailsViewModel>()
                .FirstOrDefault();

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShopCreateInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var shop = this.mapper.Map<Shop>(inputModel);
            var id = await this.shopsRepository.CreateAsync(shop);

            return this.RedirectToAction("Details", new { id });
        }
    }
}