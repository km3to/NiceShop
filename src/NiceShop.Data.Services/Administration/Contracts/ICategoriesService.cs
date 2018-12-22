using System.Linq;
using System.Threading.Tasks;
using NiceShop.ViewModels.Categories;

namespace NiceShop.Data.Services.Administration.Contracts
{
    public interface ICategoriesService
    {
        IQueryable<AllCategoriesViewModel> GetAll();

        Task CreateAsync(string name);
    }
}