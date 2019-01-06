using System.Collections.Generic;
using System.Threading.Tasks;
using NiceShop.Web.Models.Administration.InputModels;
using NiceShop.Web.Models.Administration.ViewModels;

namespace NiceShop.Data.Services.Administration.Contracts
{
    public interface IShopService
    {
        IEnumerable<ShopAllViewModel> GetAll();

        Task<string> CreateAsync(ShopCreateInputModel inputModel);

        ShopCreateInputModel GetById(string id);

        ShopCategoryDeleteViewModel GetDeleteModel(string id);

        Task UpdateAsync(ShopCreateInputModel inputModel);

        Task DeleteAsync(string id);
    }
}