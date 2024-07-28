namespace ng.api.DTOs
{
    public class CustomerDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
    }

    public class ErrorDto
    {
        public required string Message { get; set; }
        public required string ErrorCode { get; set; }
    }
}
