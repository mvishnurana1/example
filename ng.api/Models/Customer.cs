namespace ng.api.Models
{
    public class Customer
    {
        public required int Id { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
    }

    public class Order
    {
        public required int Id { get; set; }
        public required DateTime OrderDate { get; set; }
        public required Customer Customer { get; set; }
        public required int CustomerId { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }

    public class Product
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required double Price { get; set; }
        public required string ImageUrl { get; set; }
    }

    public class OrderProduct
    {
        public required int OrderId { get; set; }
        public required Order Order { get; set; }
        public required int ProductId { get; set; }
        public required Product Product { get; set; }
        public required int Quantity { get; set; }
    }
}
