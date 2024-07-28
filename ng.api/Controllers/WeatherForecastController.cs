using Microsoft.AspNetCore.Mvc;
using ng.api.DTOs;

namespace ng.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        //[HttpGet(Name = "GetCustomers")]
        //public IEnumerable<CustomerDto> GetCustomers()
        //{
        //    return new List<CustomerDto>
        //    {
        //        new CustomerDto
        //        {
        //            Email = "mvishnurana@gmail.com",
        //            Name = "Vishnu Rana",
        //            Role = "User",
        //        },
        //        new CustomerDto
        //        {
        //            Email = "maaheshmail.com",
        //            Name = "Mahesh Rana",
        //            Role = "Admin",
        //        },
        //        new CustomerDto
        //        {
        //            Email = "vishalrana@gmail.com",
        //            Name = "Vishal Rana",
        //            Role = "User",
        //        },
        //    };
        //}

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customers = new List<CustomerDto>
            {
                new CustomerDto
                {
                    Email = "mvishnurana@gmail.com",
                    Name = "Vishnu Rana",
                    Role = "User",
                },
                new CustomerDto
                {
                    Email = "maaheshmail.com",
                    Name = "Mahesh Rana",
                    Role = "Admin",
                },
                new CustomerDto
                {
                    Email = "vishalrana@gmail.com",
                    Name = "Vishal Rana",
                    Role = "User",
                },
            };

            if (id > 3)
            {
                return NotFound(new ErrorDto
                { 
                    Message = $"id: {id} not found in the system",
                    ErrorCode = "404",
                });
            }

            var admin = customers.Where(customer => customer.Role == "Admin").FirstOrDefault();

            return Ok(admin);
        }
    }
}
