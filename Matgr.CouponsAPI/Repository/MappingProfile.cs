using AutoMapper;
using Matgr.CouponsAPI.Models;
using Matgr.CouponsAPI.Models.Dtos;

namespace Matgr.CouponsAPI.Repository
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Coupon, CouponDto>().ReverseMap();
        }
    }
}
