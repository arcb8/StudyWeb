using StudyWeb.Entities;

namespace StudyWeb.Repositories;

public interface IBookRepository
{
    public List<Book> GetAll();
    public Book Get(int id);
    public Book Create(Book book);
    public Book Update(int id, Book book);
    public int Delete(int id);
}