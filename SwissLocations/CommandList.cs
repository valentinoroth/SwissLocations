using System;
using System.Collections.Generic;
using System.Text;

namespace SwissLocations
{
    public class CommandList
    {
        private List<Command> commands = new List<Command>();

        public void Add(Command command)
        {
            commands.Add(command);
            //commands.Sort();
        }

        public void Execute(string cmdline)
        {
            if (String.IsNullOrWhiteSpace(cmdline))
                return;
            cmdline = cmdline.Trim();
            foreach (var c in commands)
            {
                if (c.Match(cmdline, out var param))
                {
                    if (c.Parameter != null && param == null)
                    {
                        Console.Write($"{c.Parameter}: ");
                        param = Console.ReadLine().Trim();
                        if (String.IsNullOrWhiteSpace(param))
                        {
                            Console.WriteLine($"Le paramètre \"{c.Parameter}\" est requis");
                            return;
                        }
                    }
                    Console.WriteLine(c.Execute(param));
                    return;
                }
            }
            Console.WriteLine("Commande invalide");
        }

        public string ToString()
        {
            var sb = new StringBuilder();
            foreach (var s in commands)
            {
                sb.Append(s);
                sb.Append(" : ");
                sb.Append(s.Description);
                sb.AppendLine();
            }
            return sb.ToString();

        }
    }
}
