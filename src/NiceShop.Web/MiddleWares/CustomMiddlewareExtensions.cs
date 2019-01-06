using Microsoft.AspNetCore.Builder;
using NiceShop.Web.MiddleWares.Seeders;

namespace NiceShop.Web.MiddleWares
{
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseSeedData(this IApplicationBuilder builder)
        {
            return builder
                .UseMiddleware<SeedShop>()
                .UseMiddleware<SeedCategory>();
        }

        public static IApplicationBuilder UseSeedCategory(this IApplicationBuilder builder)
        {
            return builder;
        }

        //public static IApplicationBuilder UseCustomExceptiontusMiddleware(this IApplicationBuilder builder)
        //{
        //    return builder.UseMiddleware<CustomExceptionMiddleware>();
        //}
    }
}