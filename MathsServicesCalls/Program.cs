using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebServiceConsumer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // HttpClient is generally used as a singleton, but we'll use it here for simplicity
            using (HttpClient client = new HttpClient())
            {
                // Set the base URL for your API
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");

                // Set request headers (optional, depending on the API)
                client.DefaultRequestHeaders.Add("User-Agent", "C# Client");

                try
                {
                    // Make an asynchronous GET request to the API endpoint
                    HttpResponseMessage response = await client.GetAsync("/todos/2");

                    // Ensure the response is successful
                    response.EnsureSuccessStatusCode();

                    // Read the response content as a string (JSON in this case)
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Output the response to the console
                    Console.WriteLine("Response from API:");
                    Console.WriteLine(responseBody);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request failed: {e.Message}");
                }
            }
        }
    }
}
