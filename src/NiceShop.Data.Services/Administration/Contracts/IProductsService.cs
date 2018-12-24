using System.Linq;
using System.Threading.Tasks;
using NiceShop.Data.Models;

namespace NiceShop.Data.Services.Administration.Contracts
{
    public interface IProductsService
    {
        Task<string> CreateAsync(Product model);

        IQueryable<Product> GetById(string id);

        bool IsNameValid(string name);

        bool IsCodeValid(string code);
    }
}