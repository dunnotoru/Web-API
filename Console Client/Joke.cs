using System.Text.Json.Serialization;

namespace Console_Client
{
    [JsonSerializable(typeof(Joke))]
    public class Joke 
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("header")]
        public string? Header { get; set; }
        [JsonPropertyName("body")]
        public string Body { get; set; }
    }
}
