﻿using System.ComponentModel.DataAnnotations;
using NiceShop.AutoMapping;
using NiceShop.Data.Models;
using NiceShop.Web.CustomAttributes.ValidationAttributes;

namespace NiceShop.Web.Areas.Administration.Models.BindingModels
{
    // TODO: Validation for CategoryId and ShopId
    public class ProductsCreateBindingModel : IMapTo<Product> //, IHaveCustomMappings
    {
        [Display(Name = "Код")]
        [UniqueProductCode(ErrorMessage = "Продукт с такъв код вече съществува!")]
        public string Code { get; set; }

        [Display(Name = "Име")]
        [Required(ErrorMessage = "{0}то е задължително!")]
        [MinLength(4, ErrorMessage = "{0}то трябва да е с дължина поне 4 символа!")]
        [UniqueProductName(ErrorMessage = "Продукт с такова име вече съществува!")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Брой")]
        [Range(0, 9999, ErrorMessage = "Бpойката може да е в диапазона [0 - 999]")]
        public int Count { get; set; }

        [Display(Name = "Категория")]
        public string CategoryId { get; set; }

        [Display(Name = "Магазин")]
        public string ShopId { get; set; }

        [Display(Name = "Адрес на изображението")]
        [Url]
        public string ImageUrl { get; set; }

        [Display(Name = "Доставна цена")]
        [Required(ErrorMessage = "{0}то е задължително!")]
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue)]
        public decimal BoughtFor { get; set; }

        [Display(Name = "Продажна цена")]
        [Required(ErrorMessage = "{0}то е задължително!")]
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue)]
        [GreaterThan("BoughtFor", ErrorMessage = "Продажната цена трябва да бъде по голяма от доставната!")]
        public decimal Price { get; set; }

        //public void CreateMappings(IMapperConfigurationExpression configuration)
        //{
        //    configuration.CreateMap<Product, CreateProductViewModel>()
        //        .ForMember(x => x.CategoryId, x => x.MapFrom(j => j.Category.Id));
        //}
    }
}