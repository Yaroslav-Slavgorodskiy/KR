using System.Linq;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void RegisterUser(string username, string password)
    {
        if (_userRepository.ReadAll().Any(u => u.Username == username))
        {
            throw new Exception("Користувач з таким ім'ям вже існує.");
        }

        var newUser = new User(username, password);
        _userRepository.Create(newUser);
    }

    public User Login(string username, string password)
    {
        var user = _userRepository.ReadAll().FirstOrDefault(u => u.Username == username && u.Password == password);

        if (user == null)
        {
            throw new Exception("Некоректне ім'я користувача або пароль. Спробуйте ще раз");
        }

        return user;
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _userRepository.ReadAll();
    }

public void AddBalance(User user, decimal amount)
{
    if (amount <= 0)
        throw new ArgumentException("Сума повинна бути більшою за 0.");

    Console.WriteLine("Баланс оновлено:");
    Console.WriteLine($"[Before Update] ID: {user.Id}, Username: {user.Username}, Balance: {user.Balance:F2}");

    user.AddToBalance(amount);

    Console.WriteLine($"[After Update] ID: {user.Id}, Username: {user.Username}, Balance: {user.Balance:F2}");

    _userRepository.Update(user);
}

    public User? GetUserByCredentials(string username, string password)
    {
        return _userRepository.ReadAll().FirstOrDefault(u => u.Username == username && u.Password == password);
    }
     public User ReadAccountById(int id)
    {
        var user = _userRepository.ReadById(id);

        if (user == null)
        {
            throw new Exception($"Користувача з ID {id} не знайдено.");
        }

        return user;
    }
}