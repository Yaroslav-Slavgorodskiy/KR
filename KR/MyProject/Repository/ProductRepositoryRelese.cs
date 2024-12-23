using System.Linq;

public class ProductRepository : IProductRepository
{
    private readonly DbContext _context;

    public ProductRepository(DbContext context)
    {
        _context = context;
    }

   public void Create(Product product)
{
    if (_context.Products.Any(p => p.Id == product.Id))
    {
        throw new InvalidOperationException($"Продукт з ID {product.Id} вже існує.");
    }

    _context.Products.Add(product);
}

    public Product? ReadById(int id) 
    {
        return _context.Products.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Product> ReadAll()
    {
        return _context.Products;
    }

    public void Update(Product product)
    {
        var existingProduct = ReadById(product.Id);
        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Quantity = product.Quantity;
        }
        else
        {
            throw new InvalidOperationException($"Продукт з ID {product.Id} не знайдено для оновлення.");
        }
    }

    public void Delete(int id)
    {
        var product = ReadById(id);
        if (product != null)
        {
            _context.Products.Remove(product);
        }
        else
        {
            throw new InvalidOperationException($"Продукт з ID {id} не знайдено для видалення.");
        }
    }
}
