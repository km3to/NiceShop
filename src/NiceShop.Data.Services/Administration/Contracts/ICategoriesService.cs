using System.Linq;
using System.Threading.Tasks;
using NiceShop.ViewModels;

namespace NiceShop.Data.Services.Administration.Contracts
{
    public interface ICategoriesService
    {
        IQueryable<IdAndNameViewModel> GetAll();

        Task CreateAsync(string name);
    }
}