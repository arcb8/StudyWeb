using Microsoft.AspNetCore.Mvc;

namespace StudyWeb.Controllers;

[ApiController]
[Route("test")]
public class Test : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Hello World!");
    }

    [HttpPost("{id}")]
    public IActionResult Post(int id)
    {
        return Ok(id);
    }
}