using System;

public class Transaction
{
    public string ProductName { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;

    public Transaction(string productName, decimal amount)
    {
        if (string.IsNullOrWhiteSpace(productName))
            throw new ArgumentException("Назва товару не може бути порожньою.");
        if (amount <= 0)
            throw new ArgumentException("Сума транзакції має бути більше 0.");

        ProductName = productName;
        Amount = amount;
    }
}