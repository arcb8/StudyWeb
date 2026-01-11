using StudyWeb.Contracts.Products;
using StudyWeb.Domain.Entities;
using StudyWeb.Repositories.Products;

namespace StudyWeb.Services.Products;

public class ProductService : IProductService
{
    private IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public List<Product> GetAll()
    {
        return _productRepository.GetAll();
    }

    public Product Get(int id)
    {
        var product = _productRepository.Get(id);
        if (product == null)
        {
            throw new InvalidDataException("Такого товара не найдено");
        }
        return product;
    }
    
    public Product Create(CreateProductRequest request)
    {
        if (request.Name == "")
        {
            throw new InvalidDataException("Не указанно название");
        }
        
        Product product = new Product
        {
            Name = request.Name,
            Price = request.Price
        };
        return _productRepository.Create(product);
    }

    public Product? Update(int id, UpdateProductRequest request)
    {
        var product = _productRepository.Get(id);
        if (product == null)
        {
            throw new InvalidDataException("Такой книги не найдено");
        }

        product.Name = request.Name;
        product.Price = request.Price;
        return _productRepository.Update(id, product);
    }

    public int Delete(int id)
    {
        return _productRepository.Delete(id);
    }
}