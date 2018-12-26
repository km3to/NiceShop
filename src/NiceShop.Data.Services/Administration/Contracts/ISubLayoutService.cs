using System.Collections.Generic;
using NiceShop.Web.Models.Administration.ViewModels;

namespace NiceShop.Data.Services.Administration.Contracts
{
    public interface ISubLayoutService
    {
        IEnumerable<IdAndNameViewModel> GetShops();

        IEnumerable<IdAndNameViewModel> GetCategories();
    }
}