using System.ComponentModel.DataAnnotations;

namespace NiceShop.Web.Models.ValidationAttributes
{
    public class GreaterThanAttribute : ValidationAttribute
    {
        private readonly string propertyName;

        public GreaterThanAttribute(string propertyName)
        {
            this.propertyName = propertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyInfo = validationContext
                .ObjectType
                .GetProperty(this.propertyName);

            var greaterValue = (decimal) value;
            var lesserValue = (decimal)propertyInfo.GetValue(validationContext.ObjectInstance, null);

            if (greaterValue > lesserValue)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(this.ErrorMessage);
        }
    }
}