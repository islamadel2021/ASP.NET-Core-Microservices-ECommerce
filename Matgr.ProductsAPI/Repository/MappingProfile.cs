using AutoMapper;
using Matgr.ProductsAPI.Models;
using Matgr.ProductsAPI.Models.Dtos;

namespace Matgr.ProductsAPI.Repository
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
