using System.Collections.Generic;

public interface IProductService
{
    IEnumerable<Product> GetAvailableProducts();

    void PurchaseProduct(User user, string productName);

    IEnumerable<Product> GetProductsByCategory(Product.ProductCategory category);
}