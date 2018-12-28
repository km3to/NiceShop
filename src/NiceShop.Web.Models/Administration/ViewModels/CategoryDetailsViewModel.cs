using NiceShop.AutoMapping;
using NiceShop.Data.Models;

namespace NiceShop.Web.Models.Administration.ViewModels
{
    public class CategoryDetailsViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}