using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SwissLocations
{
    class RestClient
    {
        private static readonly HttpClient httpClient;

        static RestClient() => httpClient = new HttpClient();

        protected async static Task<T> AsyncRequestByGet<T>(string uri)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<T>(uri);
            }
            catch (Exception e) // Non success
            {
                Console.WriteLine($"Erreur: {e.ToString()}");
            }

            return default(T);
        }

        public static T RequestByGet<T>(string uri)
        {
            var task = AsyncRequestByGet<T>(uri);
            task.Wait();
            return task.Result;
        }

    }
}
