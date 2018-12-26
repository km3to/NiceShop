using System.ComponentModel.DataAnnotations;
using NiceShop.Data.Services.Administration;

namespace NiceShop.Web.CustomAttributes.ValidationAttributes
{
    public class UniqueProductCode : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var service = (ProductsService)validationContext.GetService(typeof(ProductsService));

            if (service.IsCodeValid((string)value))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(this.ErrorMessage);
        }
    }
}