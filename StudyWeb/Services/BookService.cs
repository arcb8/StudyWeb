using StudyWeb.Contracts;
using StudyWeb.Entities;
using StudyWeb.Repositories;

namespace StudyWeb.Services;

public class BookService : IBookService
{
    private IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    
    public List<Book> GetAll()
    {
        return _bookRepository.GetAll();
    }

    public Book Get(int id)
    {
        var book = _bookRepository.Get(id);
        if (book == null)
        {
            throw new InvalidDataException("Такой книги не найдено");
        }
        return book;
    }
    
    public Book Create(CreateRequest request)
    {
        if (request.Title == "")
        {
            throw new InvalidDataException("Не указанно название");
        }
        
        Book book = new Book
        {
            Title = request.Title,
            Author = request.Author
        };
        return _bookRepository.Create(book);
    }

    public Book? Update(int id, UpdateRequest request)
    {
        var book = _bookRepository.Get(id);
        if (book == null)
        {
            throw new InvalidDataException("Такой книги не найдено");
        }

        book.Title = request.Title;
        book.Author = request.Author;
        return _bookRepository.Update(id, book);
    }

    public int Delete(int id)
    {
        return _bookRepository.Delete(id);
    }
}