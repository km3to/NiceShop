using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            IRepository<Category> categoryRepository)
        {
            if (!categoryRepository.ReadAll().Any())
            {
                var category = new Category
                {
                    Name = WebConstants.OtherCategoryName,
                };

                await categoryRepository.CreateAsync(category);
            }

            await this.next(context);
        }
    }
}