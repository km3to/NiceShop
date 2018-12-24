using System.ComponentModel.DataAnnotations;

namespace NiceShop.Web.Areas.Administration.Models.BindingModels
{
    public class CreateCategoryBindingModel
    {
        [Required(ErrorMessage = "Полето {0} е задължително!")]
        [Display(Name = "Име")]
        public string Name { get; set; }
    }
}