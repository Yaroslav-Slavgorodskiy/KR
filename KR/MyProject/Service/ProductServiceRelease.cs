public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IEnumerable<Product> GetAvailableProducts()
    {
        return _productRepository.ReadAll().Where(p => p.Quantity > 0); 
    }

    public void PurchaseProduct(User user, string productName)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "Користувач не може бути null.");
        }

        if (string.IsNullOrWhiteSpace(productName))
        {
            throw new ArgumentException("Назва товару не може бути порожньою.");
        }

        var product = _productRepository.ReadAll()
            .FirstOrDefault(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));

        if (product == null)
        {
            throw new Exception("Товар не знайдено.");
        }

        if (product.Quantity <= 0)
        {
            throw new Exception("Товар закінчився на складі.");
        }

        if (user.Balance < product.Price)
        {
            throw new Exception("Недостатньо коштів на балансі. Перевірте будь ласка баланс");
        }

        user.DeductBalance(product.Price);

        product.Quantity--;

        user.PurchaseHistory.Add(new Transaction(product.Name, product.Price));

        _productRepository.Update(product);
    }

    public IEnumerable<Product> GetProductsByCategory(Product.ProductCategory category)
    {
        return _productRepository.ReadAll().Where(p => p.Category == category && p.Quantity > 0); 
       
    }
}
