using Application.Services;
using Domain.Entities;
using Infrastructure.External.Models;
using Infrastructure.External.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace RickAndMortyDavivienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterApiController : ControllerBase
    {
        private readonly LocationService _locationService;
        private readonly CharacterApiRepository _characterApiRepository;
        private readonly CharacterService _characterService;

        public CharacterApiController(CharacterApiRepository characterApiRepository, CharacterService characterService, LocationService locationService)
        {
            _locationService = locationService;
            _characterApiRepository = characterApiRepository;
            _characterService = characterService;
        }

        [HttpGet("LoadData")]
        public async Task<IActionResult> LoadData()
        {

            try
            {
                var locationsApi = await _characterApiRepository.GetCharactersAsync();

                var characters = new List<Character>();

                // Ciclo costoso pero necesario para reconstruir la relacion de las entidades en base de datos

                foreach (var character in locationsApi)
                {
                    var newCharacter = new Character
                    {
                        Id = character.Id,
                        Name = character.Name,
                        Type = character.Type,
                        Created = character.Created,
                        Gender = character.Gender,
                        Url = character.Url,
                        Image = character.Image,
                        Species = character.Species,
                        Status = character.Status,
                        LocationId = getLocationIdByUrl(character.Location.Url) == 0 || getLocationIdByUrl(character.Location.Url) > 20 ? null : getLocationIdByUrl(character.Location.Url),
                        OriginId = getLocationIdByUrl(character.Origin.Url) == 0 || getLocationIdByUrl(character.Location.Url) > 20 ? null : getLocationIdByUrl(character.Origin.Url)
                    };

                    characters.Add(newCharacter);
                }

                await _characterService.AddRangeAsync(characters);
                return Ok(characters);
            }
            catch (Exception e)
            {

                throw;
            }           
        }

        private int getLocationIdByUrl(string url)
        {
            if(string.IsNullOrWhiteSpace(url)) return 0;

            return int.Parse(url.Split('/')[^1]);
        }
    }
}






