using StudyWeb.Contracts;
using StudyWeb.Entities;

namespace StudyWeb.Services;

public interface IBookService
{
    public List<Book> GetAll();
    public Book Get(int id);
    public Book Create(CreateRequest request);
    public Book? Update(int id, UpdateRequest request);
    public int Delete(int id);
}