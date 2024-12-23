using System;

public class Product
{
    public enum ProductCategory
    {
        Electronics,
        Products,
        Tools
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public ProductCategory Category { get; set; }

    public Product(int id, string name, decimal price, int quantity, ProductCategory category)
    {
        if (id <= 0)
            throw new ArgumentException("Ідентифікатор має бути більше 0.");
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Назва товару не може бути порожньою.");
        if (price <= 0)
            throw new ArgumentException("Ціна товару має бути більше 0.");
        if (quantity < 0)
            throw new ArgumentException("Кількість товару не може бути від'ємною.");

        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
        Category = category;
    }

    public void ReduceQuantity(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Кількість має бути більше 0.");
        if (Quantity < quantity || Quantity < 0)
            throw new InvalidOperationException("Недостатньо товару на складі.");
        Quantity -= quantity;
    }
}