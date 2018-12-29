using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NiceShop.Web.Models.Administration.InputModels;
using NiceShop.Web.Models.Administration.ViewModels;

namespace NiceShop.Data.Services.Administration.Contracts
{
    public interface IProductsService
    {
        Task<string> CreateAsync(ProductCreateInputModel inputModel);

        ProductDetailsViewModel DetailsFor(string id);

        Task SaveImages(string productId, IEnumerable<IFormFile> images);
    }
}