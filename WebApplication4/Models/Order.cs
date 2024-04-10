namespace WebApplication4.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserID {  get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
