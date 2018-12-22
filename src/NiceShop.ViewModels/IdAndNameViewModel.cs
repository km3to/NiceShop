using System.ComponentModel.DataAnnotations;

namespace NiceShop.ViewModels
{
    public class IdAndNameViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Име")]
        [Required(ErrorMessage = "{0} е задължително поле!")]
        public string Name { get; set; }
    }
}