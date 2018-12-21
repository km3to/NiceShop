using System.Threading.Tasks;
using NiceShop.ViewModels.Products;

namespace NiceShop.Data.Services.Administration.Contracts
{
    public interface IProductsService
    {
        Task<string> CreateAsync(CreateProductViewModel viewModel);

        CreateProductViewModel GetById(string id);
    }
}