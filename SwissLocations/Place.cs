using System;
using System.Collections.Generic;
using System.Text;

namespace SwissLocations
{
    public class Place
    {
        public string Canton { get; set; }
        public string Location { get; set; }
        public string Npa { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (!String.IsNullOrWhiteSpace(Npa))
            {
                sb.Append(Npa);
                sb.Append(" ");
            }

            if (!String.IsNullOrWhiteSpace(Location))
                sb.Append(Location);


            if (!String.IsNullOrWhiteSpace(Canton))
            {
                sb.Append(", ");
                sb.Append(Canton);
            }
            return sb.ToString();
        }

    }
}
