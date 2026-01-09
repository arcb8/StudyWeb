using System.Text.Json;
using StudyWeb.Entities;

namespace StudyWeb.Repositories;

public class BookFileRepository : IBookRepository
{
    private string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "books.json");
    
    public List<Book> GetAll()
    {
        string jsonString = File.ReadAllText(_filePath);
        var library = JsonSerializer.Deserialize<List<Book>>(jsonString) ?? [];
        return library;
    }

    public Book Get(int id)
    {
        var books = GetAll();
        
        for (var i = 0; i < books.Count; i++)
        {
            if (books[i].Id == id)
            {
                return books[i];
            }
        }

        return null;
    }

    public Book Create(Book book)
    {
        var books = GetAll();
        book.Id = books.Count + 1;
        books.Add(book);
        WriteAllToFile(books);

        return book;
    }

    public Book Update(int id, Book book)
    {
        var books = GetAll();

        for (var i = 0; i < books.Count; i++)
        {
            if (books[i].Id == id)
            {
                books[i].Title = book.Title;
                books[i].Author = book.Author;
                return books[i];
            }
        }

        WriteAllToFile(books);
        return null;
    }

    public int Delete(int id)
    {
        var books = GetAll();

        for (var i = 0; i < books.Count; i++)
        {
            if (books[i].Id == id)
            {
                books.RemoveAt(i);
            }
        }
        
        WriteAllToFile(books);
        return id;
    }

    private void WriteAllToFile(List<Book> books)
    {
        string json = JsonSerializer.Serialize(books, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(_filePath, json);
    }
}
