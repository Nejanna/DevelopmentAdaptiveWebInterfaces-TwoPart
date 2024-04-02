using WebApplication4.Models;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly List<Order> _orders;

        public OrderService()
        {
            _orders = new List<Order>
            {
                new Order { Id = 1, TotalAmount = 25.99m, OrderItems = new List<OrderItem> { new OrderItem { MenuItemId = 1, Quantity = 2 } } },
                new Order { Id = 2, TotalAmount = 18.50m, OrderItems = new List<OrderItem> { new OrderItem { MenuItemId = 2, Quantity = 1 } } },
                new Order { Id = 3, TotalAmount = 32.75m, OrderItems = new List<OrderItem> { new OrderItem { MenuItemId = 4, Quantity = 1 } } },
                new Order { Id = 4, TotalAmount = 22.00m, OrderItems = new List<OrderItem> { new OrderItem { MenuItemId = 5, Quantity = 1 } } },
                new Order { Id = 5, TotalAmount = 17.25m, OrderItems = new List<OrderItem> { new OrderItem { MenuItemId = 6, Quantity = 1 }} },
                new Order { Id = 6, TotalAmount = 14.99m, OrderItems = new List<OrderItem> { new OrderItem { MenuItemId = 10, Quantity = 2 } } },
                new Order { Id = 7, TotalAmount = 27.49m, OrderItems = new List<OrderItem> { new OrderItem { MenuItemId = 3, Quantity = 1 } } },
                new Order { Id = 8, TotalAmount = 20.75m, OrderItems = new List<OrderItem> { new OrderItem { MenuItemId = 4, Quantity = 1 } } },
                new Order { Id = 9, TotalAmount = 16.00m, OrderItems = new List<OrderItem> { new OrderItem { MenuItemId = 5, Quantity = 2 } } },
                new Order { Id = 10, TotalAmount = 24.50m, OrderItems = new List<OrderItem> { new OrderItem { MenuItemId = 1, Quantity = 1 }} }
            };
        }

        public Task<List<Order>> GetOrders()
        {
            return Task.FromResult(_orders);
        }

        public Task<Order> GetOrder(int id)
        {
            return Task.FromResult(_orders.FirstOrDefault(order => order.Id == id));
        }

        public Task<int> CreateOrder(Order order)
        {
            order.Id = _orders.Count + 1;
            _orders.Add(order);
            return Task.FromResult(order.Id);
        }

        public Task UpdateOrder(Order order)
        {
            var existingOrder = _orders.FirstOrDefault(o => o.Id == order.Id);
            if (existingOrder != null)
            {
                existingOrder.TotalAmount = order.TotalAmount;
                existingOrder.OrderItems = order.OrderItems;
            }
            else
            {
                throw new ArgumentException("Order not found.");
            }
            return Task.CompletedTask;
        }

        public Task DeleteOrder(int id)
        {
            var existingOrder = _orders.FirstOrDefault(order => order.Id == id);
            if (existingOrder != null)
            {
                _orders.Remove(existingOrder);
            }
            else
            {
                throw new ArgumentException("Order not found.");
            }
            return Task.CompletedTask;
        }
    }
}
