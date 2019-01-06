using System;
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

        public ShopCreateInputModel GetById(string id)
        {
            var viewModel = this.shopRepository
                .ReadById(id)
                .To<ShopCreateInputModel>()
                .FirstOrDefault();

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

        public async Task UpdateAsync(ShopCreateInputModel inputModel)
        {
            var shopToEdit = this.shopRepository
                .ReadById(inputModel.Id)
                .FirstOrDefault();

            if (shopToEdit == null)
            {
                throw new NullReferenceException($"No shop with id: {inputModel.Id} in database.");
            }

            shopToEdit.Name = inputModel.Name;
            shopToEdit.Address = inputModel.Address;
            shopToEdit.Description = inputModel.Description;

            await this.shopRepository.UpdateAsync(shopToEdit);
        }

        public async Task DeleteAsync(string id)
        {
            await this.shopRepository.DeleteAsync(id);
        }
    }
}