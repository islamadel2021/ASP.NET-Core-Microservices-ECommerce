using Matgr.ProductsAPI.Models.Dtos;
using Matgr.ShoppingCartAPI.Models.Dtos;
using Newtonsoft.Json;

namespace Matgr.ShoppingCartAPI.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly HttpClient _httpClient;

        public CouponRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CouponDto> GetCouponByCode(string couponCode)
        {
            var response = await _httpClient.GetAsync($"/api/coupon/{couponCode}");
            var content = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<ShoppingCartResponseDto>(content);
            if (res.IsSuccess)
            {
                return JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(res.Result));
            }
            return new CouponDto();
        }
    }
}
