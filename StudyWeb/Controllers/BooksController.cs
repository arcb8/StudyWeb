using Microsoft.AspNetCore.Mvc;

namespace StudyWeb.Controllers;

[ApiController]
[Route("books")]
public class BooksController : ControllerBase
{
    public static List<Book> library = [];
    
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(library);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        for (var i = 0; i < library.Count; i++)
        {
            if (library[i].Id == id)
            {
                return Ok(library[i]);
            }
        }

        return BadRequest("Книга не найдена");
    }

    [HttpPost]
    public IActionResult Create(CreateRequest request)
    {
        Book book = new Book
        {
            Id = library.Count + 1,
            Title = request.Title,
            Author = request.Author
        };
        library.Add(book);
        return Ok(book);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        for (var i = 0; i < library.Count; i++)
        {
            if (library[i].Id == id)
            {
                library.RemoveAt(i);
            }
        }
        return Ok(id);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateRequest request)
    {
        for (var i = 0; i < library.Count; i++)
        {
            if (library[i].Id == id)
            {
                library[i].Title = request.Title;
                library[i].Author = request.Author;
            }
        }

        return Ok("Объект заменен");
    }
}

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
}

public class CreateRequest
{
    public string Title { get; set; }
    public string Author { get; set; }
}

public class UpdateRequest
{
    public string Title { get; set; }
    public string Author { get; set; }
}