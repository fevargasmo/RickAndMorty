using Newtonsoft.Json;

namespace Infrastructure.External.Models
{
    public class LocationApi
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("dimension")]
        public string Dimension { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }
    }
}
