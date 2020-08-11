using System;
using System.Linq;

namespace SwissLocations
{
    class Program
    {

        static void Main(string[] args)
        {
            CommandList commands = new CommandList();
            commands.Add(new ExitCommand());
            commands.Add(new ListCantonCommand());
            commands.Add(new ListCityCommand());
            commands.Add(new ListNpaCommand());
            commands.Add(new ShowCityCommand());
            commands.Add(new HelpCommand(commands));

            while (true)
            {
                Console.Write("> ");
                commands.Execute(Console.ReadLine());
            }

        }
    }
}
