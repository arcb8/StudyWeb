using Microsoft.AspNetCore.Mvc;
using StudyWeb.Contracts;
using StudyWeb.Services;

namespace StudyWeb.Controllers;

[ApiController]
[Route("books")]
public class BooksController : ControllerBase
{
    private IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_bookService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_bookService.Get(id));
    }

    [HttpPost]
    public IActionResult Create(CreateRequest request)
    {
        return Ok(_bookService.Create(request));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok(_bookService.Delete(id));
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateRequest request)
    {
        return Ok(_bookService.Update(id, request));
    }
}