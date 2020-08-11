using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SwissLocations
{
    public class SwissStateClient
    {
        public static readonly string BaseUri = "https://swiss-state-npa-location.herokuapp.com";

        public static List<string> GetList(string name) => RestClient.RequestByGet<List<string>>($"{BaseUri}/{name}");
        public static List<Place> GetLocations(string name) => RestClient.RequestByGet<List<Place>>($"{BaseUri}/{name}");
        public static List<string> GetCity() => GetList("localites");
        public static List<string> GetCanton() => GetList("cantons");
        public static List<string> GetNpa() => GetList("npas");
        public static List<Place> GetCityByName(string name)
        {
            name = name.Trim();
            var places = GetLocations($"localite/{name}");
            foreach (var p in places)
                p.Location = name;
            return places;
        }

        public static List<Place> GetCityByNpa(string npa)
        {
            npa = npa.Trim();
            var places = GetLocations($"npa/{npa}");
            foreach (var p in places)
                p.Npa = npa;
            return places;
        }

    }
}
