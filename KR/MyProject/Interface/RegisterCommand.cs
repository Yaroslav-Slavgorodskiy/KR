public class RegisterCommand : ICommand
{
    private readonly UserService _userService;

    public string Name => "1. Зареєструватися";

    public RegisterCommand(UserService userService)
    {
        _userService = userService;
    }

    public void Execute()
    {
        Console.Write("Введіть ім'я користувача: ");
        var username = Console.ReadLine();
        Console.Write("Введіть пароль: ");
        var password = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Ім'я користувача та пароль не можуть бути порожніми.");
            return;
        }

        try
        {
            _userService.RegisterUser(username, password);
            Console.WriteLine("Реєстрація успішна!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}