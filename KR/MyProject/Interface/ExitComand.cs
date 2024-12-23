public class ExitCommand : ICommand
{
    public string Name => "3. Вийти";

    public void Execute()
    {
        Console.WriteLine("До побачення!");
        Environment.Exit(0);
    }
}