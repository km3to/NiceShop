using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NiceShop.Common;
using NiceShop.Data.Models;
using NiceShop.Data.Repositories.Contracts;

namespace NiceShop.Web.Common.MiddleWares.Seeders
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
                    Name = WebConstants.OnlineShopName,
                };

                await shopRepository.CreateAsync(shop);
            }

            await this.next(context);
        }
    }
}