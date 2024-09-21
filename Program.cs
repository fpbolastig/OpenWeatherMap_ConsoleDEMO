using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace OpenWeatherMap_ConsoleDEMO
{
    class Program
    {
        private static readonly string APIKey = "bc97e27f7ab7edd5abafb980b7301d19"; 
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            Console.WriteLine("Input a City (ex. Manila): ");
            string sCity = Console.ReadLine();

            Console.WriteLine("\nPlease wait...");
            await GetWeather_Json(sCity);
            await GetWeather_XML(sCity);
        }

        private static async Task GetWeather_Json(string city)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={APIKey}";
            var resp = await client.GetStringAsync(url);
            var weatherData = JObject.Parse(resp);

            Console.WriteLine("\nWeather Data (JSON Format):");
            Console.WriteLine(weatherData.ToString());
        }

        private static async Task GetWeather_XML(string city)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={APIKey}&mode=xml";
            var resp = await client.GetStringAsync(url);
            var weatherData = XDocument.Parse(resp);

            Console.WriteLine("\nWeather Data (XML Format):");
            Console.WriteLine(weatherData.ToString());
        }
    }
}