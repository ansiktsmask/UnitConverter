using Converter.ConsoleUI;
using Converter.ConsoleUI_BFF.LengthConverter;

internal class Program
{
    private static void Main(string[] args)
    {
        var availableUnits = new Queries().GetAvailableUnits();

        Console.WriteLine("Welcome to the Unit converter");
        Console.WriteLine(Queries.GetAvailableCommands());

        bool running = true;
        while (running)
        {
            Console.Write(": ");
            string command = Console.ReadLine() ?? string.Empty;
            command = command.Trim().ToLower();

            var splitCommand = command.Split(" ");

            if (command == "exit")
            {
                running = false;
            }
            else if (command == "help")
            {
                Console.WriteLine("List of available commands:");
                Console.Write(Queries.GetAvailableCommands());
            }
            else if (command == "units")
            {
                Console.Write(Queries.GetAvailableUnitsString());
            }
            else if (splitCommand.Length == 4)
            {
                Convert(splitCommand);
            }
            else
            {
                Console.WriteLine("Invalid command. Type 'help' for a list of commands.");
            }
        }
    }
    private static void Convert(string[] splitCommand)
    {
        try
        {
            var response = new LengthConverterBFFQeryHandler().Execute(splitCommand[1], splitCommand[3], splitCommand[0]);

            if (response.HasErrors)
            {
                foreach (var error in response.ErrorList)
                {
                    Console.WriteLine(error);
                }
                return;
            }

            Console.WriteLine(" => " + response.ConvertedValue);
        }
        catch (Exception)
        {
            Console.WriteLine("Something went horrobly wrong");
        }

    }
}

    