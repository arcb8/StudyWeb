using StudyWeb.Contracts.Products;
using StudyWeb.Entities;

namespace StudyWeb.Services.Products;

public interface IProductService
{
    public List<Product> GetAll();
    public Product Get(int id);
    public Product Create(CreateProductRequest request);
    public Product? Update(int id, UpdateProductRequest request);
    public int Delete(int id);
}