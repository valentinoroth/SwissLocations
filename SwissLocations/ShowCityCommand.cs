using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwissLocations
{
    class ShowCityCommand : Command
    {
        public ShowCityCommand() : base("show city <localite>", "Affiche les détails de la locatité indiquée") { }
        public override string Execute(string parameter = null)
        {
            if (parameter == "")
            {
                return "Veuillez entrer un paramètre";
            }

            List<Place> places;
            if (parameter.All(char.IsDigit))
            {
                places = SwissStateClient.GetCityByNpa(parameter);
            }
            else
            {
                places = SwissStateClient.GetCityByName(parameter);
            }

            StringBuilder sb = new StringBuilder();
            foreach (Place p in places)
            {
                sb.Append(p);
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
