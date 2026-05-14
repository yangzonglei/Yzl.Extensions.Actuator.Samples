using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Yzl.Extensions.Actuator.Samples.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class CacheController(IMemoryCache memoryCache) : ControllerBase
{
    [HttpGet("add")]
    public IActionResult AddCache(string name = "demo")
    {
        var value = Random.Shared.Next();
        memoryCache.Set(name, value, TimeSpan.FromDays(1));

        return Ok(new { name, value });
    }

    [HttpGet("get")]
    public IActionResult GetCache(string name = "demo")
    {
        return Ok(new { name, value = memoryCache.Get(name) });
    }
}
