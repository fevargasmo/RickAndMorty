using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class LocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<LocationDTO> GetByIdAsync(int id)
        {
            var Location = await _locationRepository.GetByIdAsync(id);
            
            return new LocationDTO { Id = Location.Id, Name = Location.Name, Type = Location.Type, Created = Location.Created, Dimension = Location.Dimension, Url = Location.Url };
        }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            return await _locationRepository.GetAllAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Location> locations)
        {
            await _locationRepository.AddRangeAsync(locations);
        }
        public async Task AddAsync(Location location)
        {
            await _locationRepository.AddAsync(location);
        }

        public async Task DeleteAsync(int id)
        {
            await _locationRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(Location location)
        {
            await _locationRepository.UpdateAsync(location);
        }
    }
}
