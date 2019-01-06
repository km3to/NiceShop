using Microsoft.AspNetCore.Builder;
using NiceShop.Web.Common.MiddleWares.Seeders;

namespace NiceShop.Web.Common.MiddleWares
{
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseSeedData(this IApplicationBuilder builder)
        {
            return builder
                .UseMiddleware<SeedShop>()
                .UseMiddleware<SeedCategory>();
        }
    }
}