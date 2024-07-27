namespace ng.api.Models
{
    public class Customer
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public class Order
    {
        public required int Id { get; set; }
        
        public required Customer User { get; set; }
        public required int UserId { get; set; }

        public required Product Product { get; set; }
        public required int ProductId { get; set; }
    }

    public class Product
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required double Price { get; set; }

        public required int ProductImageId { get; set; }
        public required ProductImage ProductImage { get; set; }
    }

    public class ProductImage
    {
        public required int Id { get; set; }
        public required byte[] ImageData { get; set; }
        public required string ContentType { get; set; }
        public required string FileName { get; set; }
    }
}
