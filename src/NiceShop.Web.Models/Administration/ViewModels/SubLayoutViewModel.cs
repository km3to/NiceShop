using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using NiceShop.Web.Models.Administration.InputModels;

namespace NiceShop.Web.Models.Administration.ViewModels
{
    public class SubLayoutViewModel
    {
        //public SubLayoutInputModel ControlPanel { get; set; }

        public string Shop { get; set; }

        public string Category { get; set; }

        public string SortTerm { get; set; }

        public IEnumerable<SelectListItem> SortTerms { get; set; }

        public IEnumerable<SelectListItem> Shops { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}