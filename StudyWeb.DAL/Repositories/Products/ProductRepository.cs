using StudyWeb.Domain.Entities;

namespace StudyWeb.Repositories.Products;

public class ProductRepository : IProductRepository
{
    private static List<Product> _products = [];
    
    public List<Product> GetAll()
    {
        return _products;
    }

    public Product? Get(int id)
    {
        for (var i = 0; i < _products.Count; i++)
        {
            if (_products[i].Id == id)
            {
                return _products[i];
            }
        }

        return null;
    }
    
    public Product Create(Product book)
    {
        book.Id = _products.Count + 1;
        _products.Add(book);
        return book;
    }

    public Product? Update(int id, Product product)
    {
        for (var i = 0; i < _products.Count; i++)
        {
            if (_products[i].Id == id)
            {
                _products[i].Name = product.Name;
                _products[i].Price = product.Price;
                return _products[i];
            }
        }

        return null;
    }

    public int Delete(int id)
    {
        for (var i = 0; i < _products.Count; i++)
        {
            if (_products[i].Id == id)
            {
                int tmp = _products[i].Id;
                _products.RemoveAt(i);
                return tmp;
            }
        }

        return -1;
    }
}