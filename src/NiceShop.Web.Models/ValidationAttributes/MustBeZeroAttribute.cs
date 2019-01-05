using System.ComponentModel.DataAnnotations;

namespace NiceShop.Web.Models.ValidationAttributes
{
    public class MustBeZeroAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var number = (int)value;

            if (number == 0)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(this.ErrorMessage);
        }
    }
}