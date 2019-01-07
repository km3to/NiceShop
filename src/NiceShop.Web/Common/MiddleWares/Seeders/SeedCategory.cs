using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NiceShop.Common;
using NiceShop.Data.Models;
using NiceShop.Data.Repositories.Contracts;

namespace NiceShop.Web.Common.MiddleWares.Seeders
{
    public class SeedCategory
    {
        private readonly RequestDelegate next;

        public SeedCategory(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(
            HttpContext context,
            IRepository<Category> categoryRepository,
            IRepository<Shop> shopRepository,
            IRepository<ShopCategory> shopCategoryRepository)
        {
            if (!categoryRepository.ReadAll().Any())
            {
                var shop = shopRepository
                    .ReadAll()
                    .FirstOrDefault(x => x.Name == WebConstants.OnlineShopName);

                var category = new Category
                {
                    Name = WebConstants.OtherCategoryName,
                };

                var shopId = shop.Id;
                var categoryId = await categoryRepository.CreateAsync(category);

                var shopCategory = new ShopCategory
                {
                    CategoryId = categoryId,
                    ShopId = shopId
                };

                await shopCategoryRepository.CreateAsync(shopCategory);
            }

            await this.next(context);
        }
    }
}