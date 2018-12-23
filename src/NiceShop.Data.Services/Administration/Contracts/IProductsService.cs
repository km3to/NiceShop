using System.Threading.Tasks;
using NiceShop.Data.Models;

namespace NiceShop.Data.Services.Administration.Contracts
{
    public interface IProductsService
    {
        Task<string> CreateAsync(Product model);

        Product GetById(string id);

        bool IsNameValid(string name);

        bool IsCodeValid(string code);
    }
}