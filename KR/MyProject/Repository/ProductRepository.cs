using System.Collections.Generic;

public interface IProductRepository
{
    void Create(Product product);
    Product? ReadById(int id); 
    IEnumerable<Product> ReadAll();
    void Update(Product product);
    void Delete(int id);
}