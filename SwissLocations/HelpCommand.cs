using System;
using System.Collections.Generic;
using System.Text;

namespace SwissLocations
{
    class HelpCommand : Command
    {
        private CommandList commands;

        public HelpCommand(CommandList commandList) : base("help", "Affiche la liste des commandes")
        {
            this.commands = commandList;
        }

        public override string Execute(string parameter = null)
        {
            return commands.ToString();
        }
    }
}
