using Matgr.OrdersAPI.Models;

namespace Matgr.OrdersAPI.Repository
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderHeader orderHeader);
        Task UpdateOrderPaymentStatus(int orderHeaderId, bool status);
    }
}
