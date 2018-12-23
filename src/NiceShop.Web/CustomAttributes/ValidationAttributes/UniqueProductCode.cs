using System.ComponentModel.DataAnnotations;
using NiceShop.Data.Services.Administration.Contracts;

namespace NiceShop.Web.CustomAttributes.ValidationAttributes
{
    public class UniqueProductCode : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var service = (IProductsService)validationContext.GetService(typeof(IProductsService));

            if (service.IsCodeValid((string)value))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(this.ErrorMessage);
        }
    }
}