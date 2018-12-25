using System.Linq;
using System.Threading.Tasks;
using NiceShop.Data.Models;

namespace NiceShop.Data.Services.Administration.Contracts
{
    public interface IProductsService
    {
        IQueryable<Product> GetById(string id);

        Task<string> CreateAsync(Product model);
        IQueryable<Product> GetAll();

        IQueryable<Product> GetAllForShop(string shopId);

        IQueryable<Product> GetAllForCategory(string categoryId);

        bool IsNameValid(string name);

        bool IsCodeValid(string code);
    }
}