using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Location> GetAll()
        {
            return _context.Set<Location>();
        }

        public async Task AddAsync(Location location)
        {
            await _context.Set<Location>().AddAsync(location);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var location = await _context.Location.FindAsync(id);
            if (location != null)
            {
                _context.Location.Remove(location);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            return _context.Location.AsEnumerable();
        }

        public async Task<Location> GetByIdAsync(int id)
        {
            return _context.Set<Location>().First(c => c.Id == id);
        }

        public async Task UpdateAsync(Location location)
        {
            _context.Location.Update(location);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Location> locations)
        {
            await _context.Set<Location>().AddRangeAsync(locations);
            await _context.SaveChangesAsync();
        }
    }
}
