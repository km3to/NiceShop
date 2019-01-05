using System.Collections.Generic;
using System.Threading.Tasks;
using NiceShop.Web.Models.Administration.InputModels;
using NiceShop.Web.Models.Administration.ViewModels;

namespace NiceShop.Data.Services.Administration.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<CategoryAllViewModel> GetAll();

        Task<string> CreateAsync(CategoryCreateInputModel inputModel);

        IdAndNameViewModel GetById(string id);

        Task UpdateAsync(IdAndNameViewModel inputModel);

        Task DeleteAsync(string id);
    }
}