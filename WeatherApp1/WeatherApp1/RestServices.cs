using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp1;

namespace WeatherApp
{
    public class RestServices
    {
        HttpClient _client;

        public RestServices()
        {
            _client = new HttpClient();
        }

        //getting the weather data from the text input
        public async Task<Datatags1> GetDatatags1(string query)
        {
            Datatags1 Datatags = null;
            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Datatags = JsonConvert.DeserializeObject<Datatags1>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }

            return Datatags;
        }
    }
}
