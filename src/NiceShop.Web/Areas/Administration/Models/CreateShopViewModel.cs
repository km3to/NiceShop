using System.ComponentModel.DataAnnotations;

namespace NiceShop.Web.Areas.Administration.Models
{
    public class CreateShopViewModel
    {
        [Required(ErrorMessage = "Полето {0} е задължително!")]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }
    }
}