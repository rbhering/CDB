using Microsoft.AspNetCore.Mvc;

namespace CDB.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CdbController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CdbController> _logger;

        public CdbController(ILogger<CdbController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCdb")]
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

        [HttpPost(Name = "PostCdb")]
        public async Task<IActionResult> Post([FromBody] CdbRequestViiewModel cdbRequestViiewModel)
        {
            return Ok(new CdbResponseViiewModel() { ValorBruto = 25, ValorLiquido = 85});
        }
    }

    public class CdbRequestViiewModel
    {
        public int QtdMeses { get; set; }
        public decimal ValorInicial { get; set; }
    }

    public class CdbResponseViiewModel
    {
        public decimal ValorBruto { get; set; }
        public decimal ValorLiquido { get; set; }
    }

}
