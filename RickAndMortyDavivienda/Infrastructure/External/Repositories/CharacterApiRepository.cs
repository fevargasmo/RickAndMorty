using Domain.Entities;
using Infrastructure.External.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.External.Repositories
{
    public class CharacterApiRepository
    {
        private readonly ApiClient _apiClient;
        private const string BaseUrl = "https://rickandmortyapi.com/api/character";

        public CharacterApiRepository(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<CharacterApi>> GetCharactersAsync()
        {
            var jsonResponse = await _apiClient.GetAsync(BaseUrl);
            var response = JsonConvert.DeserializeObject<CharacterResponse>(jsonResponse);
            return response.Results;
        }
    }

}
