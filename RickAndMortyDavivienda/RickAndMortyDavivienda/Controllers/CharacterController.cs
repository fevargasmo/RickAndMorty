using Application.DTOs;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace RickAndMortyDavivienda.Controllers
{
    [ApiController]
    [Route("characters")]
    public class CharacterController : ControllerBase
    {
        private readonly CharacterService _characterService;

        public CharacterController(CharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var character = await _characterService.GetAllAsync();
            if (character == null)
            {
                return NotFound();
            }
            return Ok(character);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var character = await _characterService.GetByIdAsync(id);
            return Ok(character);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CharacterDTO characterDTO)
        {
            await _characterService.AddAsync(new Character
            {
                Created = characterDTO.Created,
                Image = characterDTO.Image,
                Gender = characterDTO.Gender,
                Name = characterDTO.Name,
                LocationId = characterDTO.LocationId,
                OriginId = characterDTO.OriginId,
                Species = characterDTO.Species,
                Status = characterDTO.Status,
                Type = characterDTO.Type,
                Url = characterDTO.Url,
                Id = characterDTO.Id
            });
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, CharacterDTO characterDTO)
        {
            await _characterService.UpdateAsync(new Character
            {
                Created = characterDTO.Created,
                Image = characterDTO.Image,
                Gender = characterDTO.Gender,
                Name = characterDTO.Name,
                LocationId = characterDTO.LocationId,
                OriginId = characterDTO.OriginId,
                Species = characterDTO.Species,
                Status = characterDTO.Status,
                Type = characterDTO.Type,
                Url = characterDTO.Url,
                Id = id
            });
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _characterService.DeleteAsync(id);
        }
    }
}