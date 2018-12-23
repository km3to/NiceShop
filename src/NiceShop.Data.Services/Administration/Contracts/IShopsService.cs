using System.Linq;
using System.Threading.Tasks;
using NiceShop.Data.Models;

namespace NiceShop.Data.Services.Administration.Contracts
{
    public interface IShopsService
    {
        Shop GetById(string id);

        Task<string> CreateAsync(Shop model);

        IQueryable<Shop> GetAll();

        Task CreateAsync(string name);
    }
}