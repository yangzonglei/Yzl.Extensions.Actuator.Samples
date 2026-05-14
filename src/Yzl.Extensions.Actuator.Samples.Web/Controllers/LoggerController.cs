using Microsoft.AspNetCore.Mvc;

namespace Yzl.Extensions.Actuator.Samples.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class LoggerController(ILogger<LoggerController> logger) : ControllerBase
{
    [HttpGet]
    public IActionResult Index(string str = "demo")
    {
        logger.LogWarning("LoggerController warning log: {Message}", str);
        logger.LogInformation("LoggerController information log: {Message}", str);
        logger.LogDebug("LoggerController debug log: {Message}", str);

        return Ok(new { written = true, message = str });
    }
}
