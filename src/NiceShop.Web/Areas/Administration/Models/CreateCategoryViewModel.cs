using System.ComponentModel.DataAnnotations;

namespace NiceShop.Web.Areas.Administration.Models
{
    public class CreateCategoryViewModel
    {
        [Required(ErrorMessage = "Полето {0} е задължително!")]
        [Display(Name = "Име")]
        public string Name { get; set; }
    }
}