using System;
using System.Collections.Generic;
using System.Text;

namespace SwissLocations
{
    class ListNpaCommand : Command
    {
        public ListNpaCommand() : base("list npa <filtre>", "Affiche les npa correspondantes au filtre") { }

        public override string Execute(string parameter = null)
        {
            if (parameter == "")
            {
                return "Veuillez entrer un paramètre";
            }

            var liste = SwissStateClient.GetNpa();
            var sb = new StringBuilder();
            foreach (var l in liste)
            {
                if (l.MatchWildcard(parameter))
                {
                    sb.Append(l);
                    sb.AppendLine();
                }
            }
            return sb.ToString();
        }
    }
}
