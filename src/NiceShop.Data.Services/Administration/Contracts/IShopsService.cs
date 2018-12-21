using System.Threading.Tasks;
using NiceShop.ViewModels.Shops;

namespace NiceShop.Data.Services.Administration.Contracts
{
    public interface IShopsService
    {
        Task CreateAsync(CreateShopViewModel viewModel);
    }
}