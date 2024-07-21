using Application.DTOs;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace RickAndMortyDavivienda.Controllers
{
    [ApiController]
    [Route("locations")]
    public class LocationController : ControllerBase
    {
        private readonly LocationService _locationService;

        public LocationController(LocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var character = await _locationService.GetAllAsync();
            if (character == null)
            {
                return NotFound();
            }
            return Ok(character);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var character = await _locationService.GetByIdAsync(id);
            return Ok(character);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(LocationDTO locationDTO)
        {
            await _locationService.AddAsync(new Location
            {
                Created = locationDTO.Created,
                Dimension = locationDTO.Dimension,
                Name = locationDTO.Name,
                Type = locationDTO.Type,
                Url = locationDTO.Url,
                Id = locationDTO.Id
            });
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, LocationDTO locationDTO)
        {
            await _locationService.UpdateAsync(new Location
            {
                Id = id,
                Created = locationDTO.Created,
                Dimension = locationDTO.Dimension,
                Name = locationDTO.Name,
                Type = locationDTO.Type,
                Url = locationDTO.Url                
            });
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _locationService.DeleteAsync(id);
        }
    }
}