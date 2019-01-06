using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NiceShop.Web.Models.Administration.InputModels;
using NiceShop.Web.Models.Administration.ViewModels;

namespace NiceShop.Data.Services.Administration.Contracts
{
    public interface IProductsService
    {
        ProductAllViewModel GetAll(SubLayoutInputModel inputModel);

        Task<string> CreateAsync(ProductCreateInputModel inputModel);

        ProductCreateInputModel GetById(string id);

        Task UpdateAsync(ProductCreateInputModel inputModel);

        ProductDetailsViewModel DetailsFor(string id);

        Task DeleteAsync(string id);

        Task SaveImages(string productId, ICollection<IFormFile> images);
    }
}