using System;
using System.Collections.Generic;
using System.Text;

namespace SwissLocations
{
    public class ExitCommand : Command
    {
        public ExitCommand() : base("exit", "Termine le programme") { }
        public override string Execute(string parameter = null)
        {
            Environment.Exit(0);
            return null;
        }


    }
}
