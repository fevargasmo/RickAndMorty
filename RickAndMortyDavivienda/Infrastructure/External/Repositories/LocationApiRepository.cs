using Infrastructure.External.Models;
using Newtonsoft.Json;

namespace Infrastructure.External.Repositories
{
    public class LocationApiRepository
    {
        private readonly ApiClient _apiClient;
        private const string BaseUrl = "https://rickandmortyapi.com/api/location";

        public LocationApiRepository(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<LocationApi>> GetLocationsAsync()
        {
            var jsonResponse = await _apiClient.GetAsync(BaseUrl);
            var response = JsonConvert.DeserializeObject<LocationApiResponse>(jsonResponse);
            return response.Results;
        }
    }
}
