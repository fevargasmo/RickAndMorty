using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly ApplicationDbContext _context;

        public CharacterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Character> GetAll()
        {
            return _context.Set<Character>();
        }

        public async Task AddAsync(Character character)
        {
            await _context.Set<Character>().AddAsync(character);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var character = await _context.Character.FindAsync(id);
            if (character != null)
            {
                _context.Character.Remove(character);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Character>> GetAllAsync()
        {
            return _context.Character.Include(c => c.Location).Include(c => c.Origin).AsEnumerable();
        }

        public async Task<Character> GetByIdAsync(int id)
        {
            return _context.Set<Character>().Include(c => c.Location).Include(c => c.Origin).First(c => c.Id == id);
        }

        public async Task UpdateAsync(Character character)
        {
            _context.Character.Update(character);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Character> characters)
        {
            await _context.Set<Character>().AddRangeAsync(characters);
            await _context.SaveChangesAsync();
        }
    }
}
