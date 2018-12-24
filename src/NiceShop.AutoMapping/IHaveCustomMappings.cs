using AutoMapper;

namespace NiceShop.AutoMapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}