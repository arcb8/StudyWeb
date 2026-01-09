using StudyWeb.Entities;

namespace StudyWeb.Repositories.Products;

public interface IProductRepository
{
    public List<Product> GetAll();
    public Product Get(int id);
    public Product Create(Product product);
    public Product Update(int id, Product product);
    public int Delete(int id);
}