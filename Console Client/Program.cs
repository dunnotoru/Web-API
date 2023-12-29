using System.Text.Json;

namespace Console_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();

            HttpRequestMessage message 
                = new HttpRequestMessage(HttpMethod.Get, new Uri("https://localhost:7299/api/jokes/5"));

            HttpResponseMessage response = client.Send(message);
            
            string responseBody = response.Content.ReadAsStringAsync().Result;
            //Console.WriteLine(responseBody);

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;
            Joke? j = JsonSerializer.Deserialize<Joke>(responseBody, options);

            Console.WriteLine(j.Body);
        }
    }
}