using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SwissLocations
{
    public abstract class Command
    {
        public string Name { get; private set; }
        public string Parameter { get; private set; } = null;
        public string Description { get; private set; }

        public Command(string command, string descr)
        {
            var tokens = command.Trim().ToLower().Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            foreach (var t in tokens)
            {
                if (t.StartsWith("<") && t.EndsWith(">"))
                {
                    Parameter = t.Substring(1, t.Length - 2);
                    break;
                }
                Name += t + ' ';
            }
            Name = Name.Trim();

            Description = descr.Trim();

        }

        public bool Match(string cmd, out string param)
        {
            param = "";
            cmd = Regex.Replace(cmd.Trim(), @"\s+", " ");
            var match = cmd.StartsWith(Name, StringComparison.OrdinalIgnoreCase);
            if (match && Parameter != null && cmd.Length > Name.Length)
                param = cmd.Substring(Name.Length+1);
            return match;
        }
        public override string ToString()
        {
            if (Parameter == null)
                return Name;
            return $"{Name} <{Parameter}>";
        }

        public abstract string Execute(string parameter = null);

    }
}
