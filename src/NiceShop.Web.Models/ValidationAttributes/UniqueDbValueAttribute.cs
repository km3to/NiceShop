using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using NiceShop.Data;

namespace NiceShop.Web.Models.ValidationAttributes
{
    public class UniqueDbValueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var db = validationContext.GetService<NiceShopDbContext>();
            var callingClassName = validationContext.ObjectType.Name;
            string[] split = Regex.Split(callingClassName, @"(?<!^)(?=[A-Z])");
            var entityName = split.First();
            var propertyName = validationContext.MemberName;

            var methodName = $"Is{entityName}{propertyName}Unique";

            var allMethods = this.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            var targetMethod = allMethods.FirstOrDefault(m => m.Name == methodName);

            var successResult = (bool)targetMethod.Invoke(this, new[] { db, value });

            if (successResult)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(this.ErrorMessage);
        }

        private bool IsProductNameUnique(NiceShopDbContext db, string name)
        {
            var result = db.Products.Any(x => x.Name == name);
            return !result;
        }

        private bool IsProductCodeUnique(NiceShopDbContext db, string code)
        {
            var result = db.Products.Any(x => x.Code == code);
            return !result;
        }
    }
}