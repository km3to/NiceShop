using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NiceShop.Data.Models;
using NiceShop.Data.Repositories.Contracts;

namespace NiceShop.Web.MiddleWares.Seeders
{
    public class SeedShop
    {
        private readonly RequestDelegate next;

        public SeedShop(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(
            HttpContext context,
            IRepository<Shop> shopRepository)
        {
            if (!shopRepository.ReadAll().Any())
            {
                var shop = new Shop
                {
                    // TODO: Use constant
                    Name = "Онлайн магазин",
                };

                await shopRepository.CreateAsync(shop);
            }

            await this.next(context);
        }
    }
}