using System;
using System.Collections.Generic;
using System.Linq;

public class CommandManager
{
    private readonly List<ICommand> _commands = new List<ICommand>();

    public void RegisterCommand(ICommand command)
    {
        _commands.Add(command);
    }

      public void ShowMenu()
    {
        Console.WriteLine("\nМеню:");
        foreach (var command in _commands)
        {
            Console.WriteLine(command.Name);
        }
        Console.Write("Оберіть опцію: ");
    }

    
    public void ExecuteCommand(string choice)
    {
        var command = _commands.FirstOrDefault(c => c.Name.StartsWith(choice));

        if (command != null)
        {
            command.Execute();
        }
        else
        {
            Console.WriteLine("Некоректна опція. Спробуйте ще раз.");
        }
    }
}