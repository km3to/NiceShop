using System.ComponentModel.DataAnnotations;
using NiceShop.AutoMapping;
using NiceShop.Data.Models;

namespace NiceShop.Web.Models.Administration.InputModels
{
    public class CategoryCreateInputModel : IMapTo<Category>
    {
        [Required(ErrorMessage = "Полето {0} е задължително!")]
        [Display(Name = "Име")]
        public string Name { get; set; }
    }
}