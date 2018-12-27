using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using NiceShop.Web.Models.Administration.ViewModels;

namespace NiceShop.Data.Services.Administration.Contracts
{
    public interface ISubLayoutService
    {
        IEnumerable<SelectListItem> GetShops();

        IEnumerable<SelectListItem> GetCategories();

        IEnumerable<SelectListItem> GetOrderTerms();
    }
}