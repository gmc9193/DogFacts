using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DogFacts
{
    class Program
    {
        private const string DogFactsApiUrl = "http://dog-api.kinduff.com/api/facts";

        static async Task Main(string[] args)
        {
            try
            {
                var dogFact = await FetchDogFactAsync();
                Console.WriteLine($"Here's a dog fact for you!\n{dogFact}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private static async Task<string> FetchDogFactAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(DogFactsApiUrl);
                return response.Trim(new char[] { '[', ']', '"' }); // Assuming the API returns a JSON array of strings, this trims unnecessary characters
            }
        }
    }
}