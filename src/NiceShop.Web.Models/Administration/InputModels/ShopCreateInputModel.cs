using System.ComponentModel.DataAnnotations;
using AutoMapper;
using NiceShop.AutoMapping;
using NiceShop.Data.Models;

namespace NiceShop.Web.Models.Administration.InputModels
{
    public class ShopCreateInputModel : IMapTo<Shop>, IMapFrom<Shop>, IHaveCustomMappings
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Полето {0} е задължително!")]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<ShopCreateInputModel, Shop>();
        }
    }
}