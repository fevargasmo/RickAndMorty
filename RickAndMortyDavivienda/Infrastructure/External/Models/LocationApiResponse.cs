using Newtonsoft.Json;

namespace Infrastructure.External.Models
{
    public class LocationApiResponse
    {
        [JsonProperty("results")]
        public List<LocationApi> Results { get; set; }
    }
}
