using StudyWeb.Entities;

namespace StudyWeb.Repositories;

public class BookRepository : IBookRepository
{
    private static List<Book> _library = [];
    
    public List<Book> GetAll()
    {
        return _library;
    }

    public Book? Get(int id)
    {
        for (var i = 0; i < _library.Count; i++)
        {
            if (_library[i].Id == id)
            {
                return _library[i];
            }
        }

        return null;
    }
    
    public Book Create(Book book)
    {
        book.Id = _library.Count + 1;
        _library.Add(book);
        return book;
    }

    public Book? Update(int id, Book book)
    {
        for (var i = 0; i < _library.Count; i++)
        {
            if (_library[i].Id == id)
            {
                _library[i].Title = book.Title;
                _library[i].Author = book.Author;
                return _library[i];
            }
        }

        return null;
    }

    public int Delete(int id)
    {
        for (var i = 0; i < _library.Count; i++)
        {
            if (_library[i].Id == id)
            {
                int tmp = _library[i].Id;
                _library.RemoveAt(i);
                return tmp;
            }
        }

        return -1;
    }
}