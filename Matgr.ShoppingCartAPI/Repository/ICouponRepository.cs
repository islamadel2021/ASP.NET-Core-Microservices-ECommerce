
using Matgr.ShoppingCartAPI.Models.Dtos;

namespace Matgr.ShoppingCartAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCode(string couponCode);
    }
}
