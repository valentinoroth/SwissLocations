using System;
using System.Collections.Generic;
using System.Text;

namespace SwissLocations
{
    class ListCantonCommand : Command
    {
        public ListCantonCommand() : base("list canton", "Affiche la liste des cantons")
        {
            
        }

        public override string Execute(string parameter = null)
        {
            var liste = SwissStateClient.GetCanton();
            foreach (var l in liste)
            {
                Console.WriteLine(l);
            }
            return null;
        }
    }
}
