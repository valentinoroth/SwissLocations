using System;
using System.Collections.Generic;
using System.Text;

namespace SwissLocations
{
    class ListCityCommand : Command
    {
        public ListCityCommand() : base("list city <filtre>", "Affiche les locatités correspondantes au filtre") { }

        public override string Execute(string parameter = null)
        {
            if (parameter == "")
            {
                return "Veuillez entrer un paramètre";
            }

            var liste = SwissStateClient.GetCity();
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
