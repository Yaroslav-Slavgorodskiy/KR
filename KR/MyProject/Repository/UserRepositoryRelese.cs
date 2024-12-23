using System;
using System.Collections.Generic;
using System.Linq;

public class UserRepository : IUserRepository
{
    private readonly DbContext _context;

    public UserRepository(DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
private int GenerateUserId()
{
    return _context.Users.Any() ? _context.Users.Max(u => u.Id) + 1 : 1;
}
   public void Create(User user)
{
    if (user == null) throw new ArgumentNullException(nameof(user));
    user.Id = GenerateUserId();
    _context.Users.Add(user);
}

    public User? ReadById(int id)
    {
        return _context.Users.FirstOrDefault(u => u.Id == id);
    }

    public IEnumerable<User> ReadAll()
    {
        return _context.Users ?? Enumerable.Empty<User>();
    }

 public void Update(User user)
{
    if (user == null) throw new ArgumentNullException(nameof(user));

    var existingUser = ReadById(user.Id);
    if (existingUser != null)
    {
        existingUser.Username = user.Username;
        existingUser.Password = user.Password;
        existingUser.PurchaseHistory = user.PurchaseHistory;

        UpdateBalance(existingUser, user.Balance);
    }
    else
    {
        Console.WriteLine($"Користувача з ID {user.Id} не знайдено для оновлення.");
    }
}

    public void Delete(int id)
    {
        var user = ReadById(id);
        if (user != null)
        {
            _context.Users.Remove(user);
        }
        else
        {
            Console.WriteLine($"Користувача з ID {id} не знайдено для видалення.");
        }
    }

    private void UpdateBalance(User existingUser, decimal newBalance)
{
    var difference = newBalance - existingUser.Balance;
    if (difference > 0)
    {
        existingUser.AddToBalance(difference);
    }
    else if (difference < 0)
    {
        existingUser.DeductBalance(-difference);
    }
}
}