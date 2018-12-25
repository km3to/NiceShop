using NiceShop.AutoMapping;
using NiceShop.Data.Models;

namespace NiceShop.Web.Areas.Administration.Models.ViewModels
{
    public class DetailsCategoryViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}