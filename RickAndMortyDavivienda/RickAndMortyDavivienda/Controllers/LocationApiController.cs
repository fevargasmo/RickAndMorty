using Application.DTOs;
using Application.Services;
using Domain.Entities;
using Infrastructure.External.Repositories;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace RickAndMortyDavivienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationApiController : ControllerBase
    {
        private readonly LocationApiRepository _locationApiRepository;
        private readonly LocationService _locationService;

        public LocationApiController(LocationApiRepository locationApiRepository, LocationService locationService)
        {
            _locationApiRepository = locationApiRepository;
            _locationService = locationService;
        }

        [HttpGet("LoadData")]
        public async Task<IActionResult> LoadData()
        {
            var locationsApi = await _locationApiRepository.GetLocationsAsync();

            var locations = new List<Location>();

            foreach (var location in locationsApi)
            {
                locations.Add(new Location
                {
                    Id = location.Id,
                    Name = location.Name,
                    Type = location.Type,
                    Created = location.Created,
                    Dimension = location.Dimension,
                    Url = location.Url,
                });
            }

            await _locationService.AddRangeAsync(locations);
            return Ok(locations);
        }   
    }
}
