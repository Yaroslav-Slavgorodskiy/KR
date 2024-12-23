class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var dbContext = new DbContext();
        var userRepository = new UserRepository(dbContext);
        var productRepository = new ProductRepository(dbContext);

        var userService = new UserService(userRepository);
        var productService = new ProductService(productRepository);

        var commandManager = new CommandManager();

        commandManager.RegisterCommand(new RegisterCommand(userService));
        commandManager.RegisterCommand(new LoginCommand(userService, productService));
        commandManager.RegisterCommand(new ExitCommand());

        Console.WriteLine("Ласкаво просимо до Інтернет-магазину !");

        while (true)
        {
            commandManager.ShowMenu();
            var choice = Console.ReadLine();
            commandManager.ExecuteCommand(choice);
        }
    }
}