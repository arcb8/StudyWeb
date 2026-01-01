using Microsoft.AspNetCore.Mvc;
using StudyWeb.Contracts;
using StudyWeb.Services;

namespace StudyWeb.Controllers;

[ApiController]
[Route("books")]
public class BooksController : ControllerBase
{
    private BookService bookService = new BookService();

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(bookService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(bookService.Get(id));
    }

    [HttpPost]
    public IActionResult Create(CreateRequest request)
    {
        return Ok(bookService.Create(request));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok(bookService.Delete(id));
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateRequest request)
    {
        return Ok(bookService.Update(id, request));
    }
}