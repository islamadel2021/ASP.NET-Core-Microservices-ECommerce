using AutoMapper;
using Matgr.ShoppingCartAPI.Models;
using Matgr.ShoppingCartAPI.Models.Dto;

namespace Matgr.ProductsAPI.Repository
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
            CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
        }
    }
}
