using StudyWeb.Data;
using StudyWeb.Domain.Entities;

namespace StudyWeb.Repositories;

public class BookDbRepository : IBookRepository
{
    private AppDbContext _dbContext;

    public BookDbRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public List<Book> GetAll()
    {
        var books = _dbContext.Books.ToList();
        return books;
    }

    public Book? Get(int id)
    { 
        return _dbContext.Books.FirstOrDefault(book => book.Id == id); // LINQ
    }

    public Book Create(Book book)
    {
        _dbContext.Books.Add(book);
        _dbContext.SaveChanges();
        return book;
    }

    public Book Update(int id, Book book)
    {
        _dbContext.Books.Update(book);
        _dbContext.SaveChanges();
        return book;
    }

    public int Delete(int id)
    {
        var book = Get(id);
        _dbContext.Books.Remove(book);
        _dbContext.SaveChanges();
        return id;
    }
}