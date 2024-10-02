using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;
//Combinando ambos atributos, se configura la clase WeatherForecastController para que actúe como un controlador de API web que responde a las solicitudes en rutas que comienzan con /api/WeatherForecast. Por ejemplo, si se realiza una solicitud GET a /api/WeatherForecast/GetW, esta clase controladora responderá utilizando el método GetW definido en ella.
[ApiController]
[Route("api/[controller]")]
//Esta clase pública define un controlador en una aplicación ASP.NET Core para gestionar las solicitudes HTTP relacionadas con los pronósticos del tiempo. La herencia de ControllerBase proporciona a esta clase controlador las funcionalidades necesarias para manejar estas solicitudes de manera efectiva.
public class WeatherForecastController : ControllerBase
{
    // Este código crea una lista estática de descripciones de condiciones climáticas llamada Summaries, que puede ser utilizada en otras partes del código para generar pronósticos del tiempo con diferentes condiciones. Como es estática y readonly, su valor no cambia y se puede acceder desde otros métodos dentro de la misma clase WeatherForecastController.
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    // _logger es una variable que se utiliza para llevar a cabo el registro de información y eventos dentro de la clase WeatherForecastController. Los loggers son útiles para rastrear y diagnosticar el comportamiento de la aplicación, lo que es especialmente útil en aplicaciones ASP.NET Core para registrar eventos, errores, y mensajes informativos.
    private readonly ILogger<WeatherForecastController> _logger;
    // Crea una variable estática llamada ListWeatherForecast que es una lista de objetos de tipo WeatherForecast. 
    // static define que la variable pertenece a la clase y no a una instancia en especifico.
    private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();
    // La interfaz ILogger se inyecta en el constructor de la clase WeatherForecastController. Esto significa que se proporciona un objeto con capacidades de registro (un logger) a la clase cuando se crea una instancia de WeatherForecastController. El objeto logger proporcionado puede ser de un proveedor de registro específico, como un ConsoleLogger, un FileLogger u otro, según la configuración de la aplicación.
    // Este constructor se utiliza para inicializar una instancia de la clase WeatherForecastController y se espera que se le proporcione un objeto de registro (logger) como dependencia al crear una instancia de esta clase.
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        //_logger = logger; es una operación de asignación que establece el campo privado _logger en la instancia de la clase WeatherForecastController para que pueda utilizar el objeto logger durante su ciclo de vida. El objetologger` se inyecta en la clase para permitir la funcionalidad de registro y seguimiento de actividades en la clase, lo que es especialmente útil en aplicaciones ASP.NET Core para el monitoreo y diagnóstico.
        _logger = logger;

        if(ListWeatherForecast == null || !ListWeatherForecast.Any())
        {
                ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [Route("Get/weatherforecast")]
    [Route("Get/weatherforecast2")]
    [Route("[action]")]
    public IEnumerable<WeatherForecast> GetW()
    {
        return ListWeatherForecast;
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        ListWeatherForecast.Add(weatherForecast);

        return Ok();
    }

    [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        ListWeatherForecast.RemoveAt(index);

        return Ok();
    }
}
