using Matgr.OrdersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Matgr.OrdersAPI.OrdersAPIData
{
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
