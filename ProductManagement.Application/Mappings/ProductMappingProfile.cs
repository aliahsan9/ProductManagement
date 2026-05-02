using AutoMapper;
using ProductManagement.Application.DTOs.Product;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Mappings
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductResponseDto>()
                .ForMember(dest => dest.CategoryName,
                opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<CreateProductDto, Product>();

        }
    }
}
