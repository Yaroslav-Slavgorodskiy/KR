public class UserMenu
{
    private readonly User _user;
    private readonly UserService _userService;
    private readonly ProductService _productService;

    public UserMenu(User user, UserService userService, ProductService productService)
    {
        _user = user;
        _userService = userService;
        _productService = productService;
    }

    public void Start()
    {
        while (true)
        {
            ShowMenu();
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowAvailableProductsByCategory();
                    break;
                case "2":
                    ViewBalance();
                    break;
                case "3":
                    AddBalance();
                    break;
                case "4":
                    PurchaseProduct();
                    break;
                case "5":
                    ShowPurchaseHistory();
                    break;
                case "6":
                    Console.WriteLine("Вихід з облікового запису...");
                    return;

                default:
                    Console.WriteLine("Некоректна опція. Спробуйте ще раз.");
                    break;
            }
        }
    }

    private void ShowMenu()
    {
        Console.WriteLine("\nМеню користувача:");
        Console.WriteLine("1. Переглянути доступні товари за категоріями");
        Console.WriteLine("2. Переглянути поточний баланс");
        Console.WriteLine("3. Поповнити баланс");
        Console.WriteLine("4. Придбати товар");
        Console.WriteLine("5. Переглянути історію покупок");
        Console.WriteLine("6. Вийти з облікового запису");
        Console.Write("Оберіть опцію: ");
    }

    private void ShowAvailableProductsByCategory()
    {
        var category = SelectProductCategory();
        if (category == null)
        {
            Console.WriteLine("Некоректна категорія.");
            return;
        }

        var products = _productService.GetProductsByCategory(category.Value)
                                     .Where(p => p.Quantity > 0) 
                                     .ToList();

        if (products.Count == 0)
        {
            Console.WriteLine($"У категорії {category} нажаль наразі немає доступних товарів.");
            return;
        }

        Console.WriteLine($"\nДоступні товари у категорії {category}:");
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Name} - {product.Price:F2} грн ({product.Quantity} шт.)");
        }
    }

    private Product.ProductCategory? SelectProductCategory()
{
    Console.WriteLine("\nДоступні категорії:");

    var categories = Enum.GetValues(typeof(Product.ProductCategory))
                         .Cast<Product.ProductCategory>()
                         .ToList();

    for (int i = 0; i < categories.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {categories[i]}");
    }

    Console.Write("Оберіть категорію (введіть номер): ");
    var input = Console.ReadLine();

    if (int.TryParse(input, out int categoryIndex) && categoryIndex > 0 && categoryIndex <= categories.Count)
    {
        return categories[categoryIndex - 1];
    }

    Console.WriteLine("Некоректний вибір. Спробуйте ще раз.");
    return null;
}

    private void ViewBalance()
    {
        Console.WriteLine($"Ваш поточний баланс: {_user.Balance:F2} грн.");
    }

    private void AddBalance()
    {
        Console.Write("Введіть суму для поповнення: ");
        if (decimal.TryParse(Console.ReadLine(), out var amount) && amount > 0)
        {
            _userService.AddBalance(_user, amount);
            Console.WriteLine("Баланс успішно поповнено.");
        }
        else
        {
            Console.WriteLine("Некоректна сума.");
        }
    }

    private void PurchaseProduct()
    {
        Console.Write("Введіть назву товару: ");
        var productName = Console.ReadLine();

        try
        {
            _productService.PurchaseProduct(_user, productName);
            Console.WriteLine("Покупка успішна!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }

    private void ShowPurchaseHistory()
    {
        Console.WriteLine("\nІсторія покупок:");
        foreach (var transaction in _user.PurchaseHistory)
        {
            Console.WriteLine($"{transaction.Date}: {transaction.ProductName} - {transaction.Amount:F2} грн.");
        }
    }
}