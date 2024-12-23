public class DbContext
{
    public List<User> Users { get; set; } = new List<User>();

    public List<Product> Products { get; set; } = new List<Product>();

    public List<Transaction> Transactions { get; set; } = new List<Transaction>();


    public DbContext()
    {
        Products.Add(new Product(1, "Планшет", 2500.00m, 15, Product.ProductCategory.Electronics));
        Products.Add(new Product(2, "Ноутбук", 5000.00m, 5, Product.ProductCategory.Electronics));
        Products.Add(new Product(3, "Телефон", 3500.00m, 10, Product.ProductCategory.Electronics));
        Products.Add(new Product(4, "Навушники", 800.00m, 2, Product.ProductCategory.Electronics));
        Products.Add(new Product(5, "Повербанк", 550.00m, 8, Product.ProductCategory.Electronics));
        Products.Add(new Product(6, "Смарт-Годинник", 900.00m, 20, Product.ProductCategory.Electronics));
        Products.Add(new Product(7, "Торт", 115.00m, 20, Product.ProductCategory.Products));
        Products.Add(new Product(8, "Ковбаса", 140.00m, 20, Product.ProductCategory.Products));
        Products.Add(new Product(9, "Молоко", 55.00m, 20, Product.ProductCategory.Products));
        Products.Add(new Product(10, "Молоток", 23.10m, 100, Product.ProductCategory.Tools));
        Products.Add(new Product(11, "Викрутка", 17.00m, 25, Product.ProductCategory.Tools));
        Products.Add(new Product(12, "Шуруповерт", 405.00m, 70, Product.ProductCategory.Tools));
        Products.Add(new Product(13, "Перфоратор", 2850.00m, 10, Product.ProductCategory.Tools));

        Users.Add(new User("Міша", "пароль1") { Id = 1 }); 
        Users.Add(new User("ТестовийКористувач2", "пароль2") { Id = 2 });
    }
}
