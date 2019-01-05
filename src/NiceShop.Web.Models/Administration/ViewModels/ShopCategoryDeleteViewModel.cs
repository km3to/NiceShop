using NiceShop.AutoMapping;
using NiceShop.Data.Models;
using NiceShop.Web.Models.ValidationAttributes;

namespace NiceShop.Web.Models.Administration.ViewModels
{
    public class ShopCategoryDeleteViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        //[MustBeZero(ErrorMessage = "Не можете да изтриете категория, в която има продукти!")]
        public int ProductsCount { get; set; }
    }
}