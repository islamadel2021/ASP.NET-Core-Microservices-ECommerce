namespace Matgr.UI.Services
{
    public interface ICouponService
    {
        Task<T> GetCouponAsync<T>(string couponCode, string Token = null);
    }
}
