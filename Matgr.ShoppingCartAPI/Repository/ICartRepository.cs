using Matgr.ShoppingCartAPI.Models.Dto;
using Matgr.ShoppingCartAPI.Models.Dtos;

namespace Matgr.ShoppingCartAPI.Repository
{
    public interface ICartRepository
    {
        Task<CartDto> GetCartByUserId(string userId);
        Task<CartDto> UpsertCart(CartDto cartDto);
        Task<bool> RemoveFromCart(int cartDetailsId);
        Task<bool> UpdateCount(CountDetailsDto countDetailsDto);
        Task<bool> ApplyCoupon(string userId, string couponCode);
        Task<bool> RemoveCoupon(string userId);
        Task<bool> ClearCart(string userId);
    }
}
