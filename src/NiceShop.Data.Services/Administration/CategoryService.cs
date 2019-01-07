using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NiceShop.AutoMapping;
using NiceShop.Common;
using NiceShop.Data.Models;
using NiceShop.Data.Repositories.Contracts;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.Web.Models.Administration.InputModels;
using NiceShop.Web.Models.Administration.ViewModels;

namespace NiceShop.Data.Services.Administration
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly IRepository<Shop> shopRepository;
        private readonly IRepository<ShopCategory> shopCategoryRepository;
        private readonly IMapper mapper;

        public CategoryService(
            IRepository<Category> categoryRepository,
            IRepository<Shop> shopRepository,
            IRepository<ShopCategory> shopCategoryRepository,
            IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.shopRepository = shopRepository;
            this.shopCategoryRepository = shopCategoryRepository;
            this.mapper = mapper;
        }

        public IEnumerable<CategoryAllViewModel> GetAll()
        {
            var viewModel = this.categoryRepository
                .ReadAll()
                .To<CategoryAllViewModel>()
                .ToList();

            return viewModel;
        }

        public async Task<string> CreateAsync(CategoryCreateInputModel inputModel)
        {
            var category = this.mapper.Map<Category>(inputModel);
            var shop = this.shopRepository
                .ReadAll()
                .FirstOrDefault(x => x.Name == WebConstants.OnlineShopName);

            var categoryId = await this.categoryRepository.CreateAsync(category);
            var shopId = shop.Id;
            
            var shopCategory = new ShopCategory
            {
                CategoryId = categoryId,
                ShopId = shopId,
            };

            await this.shopCategoryRepository.CreateAsync(shopCategory);

            return categoryId;
        }

        public IdAndNameViewModel GetById(string id)
        {
            var category = this.categoryRepository
                .ReadById(id)
                .FirstOrDefault();

            var viewModel = this.mapper.Map<IdAndNameViewModel>(category);

            return viewModel;
        }

        public ShopCategoryDeleteViewModel GetDeleteModel(string id)
        {
            var viewModel = this.categoryRepository
                .ReadById(id)
                .To<ShopCategoryDeleteViewModel>()
                .FirstOrDefault();

            return viewModel;
        }

        public async Task UpdateAsync(IdAndNameViewModel inputModel)
        {
            var category = this.categoryRepository
                .ReadById(inputModel.Id)
                .FirstOrDefault();

            category.Name = inputModel.Name;

            await this.categoryRepository.UpdateAsync(category);
        }

        public async Task DeleteAsync(string id)
        {
            await this.categoryRepository.DeleteAsync(id);
        }
    }
}