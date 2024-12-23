using System;
using System.Collections.Generic;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public decimal Balance { get; private set; }
    public List<Transaction> PurchaseHistory { get; set; } = new();

    public User(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Ім'я користувача не може бути порожнім.");
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Пароль не може бути порожнім.");

        Username = username;
        Password = password;
        Balance = 0;
    }

    public void DeductBalance(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сума повинна бути більшою за 0.");
        if (Balance < amount)
            throw new InvalidOperationException("Недостатньо коштів на балансі.");
        Balance -= amount;
    }

    public void AddToBalance(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сума повинна бути більшою за 0.");
        Balance += amount;
    }
}