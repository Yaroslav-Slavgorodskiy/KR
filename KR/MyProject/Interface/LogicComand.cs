public class LoginCommand : ICommand
{
    private readonly UserService _userService;
    private readonly ProductService _productService;

    public string Name => "2. Увійти";

    public LoginCommand(UserService userService, ProductService productService)
    {
        _userService = userService;
        _productService = productService;
    }

    public void Execute()
    {
        Console.Write("Введіть ім'я користувача: ");
        var username = Console.ReadLine();
        Console.Write("Введіть пароль: ");
        var password = Console.ReadLine();

        var user = _userService.GetUserByCredentials(username, password);

        if (user == null)
        {
            Console.WriteLine("Некоректне ім'я користувача або пароль.");
            return;
        }

        Console.WriteLine($"Вітаємо, {user.Username}!");
        var userMenu = new UserMenu(user, _userService, _productService);
        userMenu.Start();
    }
}
