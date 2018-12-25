using System.Linq;
using System.Threading.Tasks;
using NiceShop.Data.Models;

namespace NiceShop.Data.Services.Administration.Contracts
{
    public interface ICategoriesService
    {
        IQueryable<Category> GetAll();

        Task CreateAsync(string name);

        IQueryable<Category> GetById(string id);
    }
}