using StudyWeb.Data;
using StudyWeb.Entities;
using StudyWeb.Repositories.Products;

namespace StudyWeb.Repositories;

public class ProductDbRepository : IProductRepository
{
    private AppDbContext _dbContext;

    public ProductDbRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public List<Product> GetAll()
    {
        var products = _dbContext.Products.ToList();
        return products;
    }

    public Product? Get(int id)
    {
        return _dbContext.Products.FirstOrDefault(product => product.Id == id);
    }

    public Product Create(Product product)
    {
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();
        return product;
    }

    public Product Update(int id, Product product)
    {
        _dbContext.Products.Update(product);
        _dbContext.SaveChanges();
        return product;
    }

    public int Delete(int id)
    {
        var product = Get(id);
        _dbContext.Products.Remove(product);
        _dbContext.SaveChanges();
        return id;
    }
}