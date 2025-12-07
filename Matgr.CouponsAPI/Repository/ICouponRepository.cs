using Matgr.CouponsAPI.Models.Dtos;

namespace Matgr.CouponsAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCode(string couponCode);
    }
}
