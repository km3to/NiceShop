using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NiceShop.AutoMapping;
using NiceShop.Data.Models;
using NiceShop.Data.Repositories.Contracts;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.Web.Models.Administration.InputModels;
using NiceShop.Web.Models.Administration.ViewModels;

namespace NiceShop.Data.Services.Administration
{
    public class ShopService : IShopService
    {
        private readonly IRepository<Shop> shopRepository;
        private readonly IMapper mapper;

        public ShopService(IRepository<Shop> shopRepository, IMapper mapper)
        {
            this.shopRepository = shopRepository;
            this.mapper = mapper;
        }

        public IEnumerable<ShopAllViewModel> GetAll()
        {
            var viewModel = this.shopRepository
                .ReadAll()
                .To<ShopAllViewModel>()
                .ToList();

            return viewModel;
        }

        public async Task<string> CreateAsync(ShopCreateInputModel inputModel)
        {
            var category = this.mapper.Map<Shop>(inputModel);
            var id = await this.shopRepository.CreateAsync(category);

            return id;
        }

        public IdAndNameViewModel GetById(string id)
        {
            var shop = this.shopRepository
                .ReadById(id)
                .FirstOrDefault();

            var viewModel = this.mapper.Map<IdAndNameViewModel>(shop);

            return viewModel;
        }

        public ShopCategoryDeleteViewModel GetDeleteModel(string id)
        {
            var viewModel = this.shopRepository
                .ReadById(id)
                .To<ShopCategoryDeleteViewModel>()
                .FirstOrDefault();

            return viewModel;
        }

        public async Task UpdateAsync(IdAndNameViewModel inputModel)
        {
            var category = this.shopRepository
                .ReadById(inputModel.Id)
                .FirstOrDefault();

            category.Name = inputModel.Name;

            await this.shopRepository.UpdateAsync(category);
        }

        public async Task DeleteAsync(string id)
        {
            await this.shopRepository.DeleteAsync(id);
        }
    }
}