using System.ComponentModel.DataAnnotations;

namespace NiceShop.Web.Models.Administration.InputModels
{
    public class CategoryCreateInputModel
    {
        [Required(ErrorMessage = "Полето {0} е задължително!")]
        [Display(Name = "Име")]
        public string Name { get; set; }
    }
}