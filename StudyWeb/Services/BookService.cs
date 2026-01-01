using StudyWeb.Contracts;
using StudyWeb.Entities;

namespace StudyWeb.Services;

public class BookService
{
    public static List<Book> library = [];
    
    public List<Book> GetAll()
    {
        return library;
    }

    public Book Get(int id)
    {
        for (var i = 0; i < library.Count; i++)
        {
            if (library[i].Id == id)
            {
                return library[i];
            }
        }

        return null;
    }
    
    public Book Create(CreateRequest request)
    {
        Book book = new Book
        {
            Id = library.Count + 1,
            Title = request.Title,
            Author = request.Author
        };
        library.Add(book);
        return book;
    }

    public Book Update(int id, UpdateRequest request)
    {
        for (var i = 0; i < library.Count; i++)
        {
            if (library[i].Id == id)
            {
                library[i].Title = request.Title;
                library[i].Author = request.Author;
                return library[i];
            }
        }

        return null;
    }

    public int Delete(int id)
    {
        for (var i = 0; i < library.Count; i++)
        {
            if (library[i].Id == id)
            {
                int tmp = library[i].Id;
                library.RemoveAt(i);
                return tmp;
            }
        }

        return -1;
    }
}