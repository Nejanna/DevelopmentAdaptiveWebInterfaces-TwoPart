using WebApplication4.Models;

namespace WebApplication4.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrders();
        Task<Order> GetOrder(int id);
        Task<int> CreateOrder(Order order);
        Task UpdateOrder(Order order);
        Task DeleteOrder(int id);
    }
}
