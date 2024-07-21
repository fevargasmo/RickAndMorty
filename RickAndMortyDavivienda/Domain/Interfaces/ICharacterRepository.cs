using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICharacterRepository
    {
        Task<Character> GetByIdAsync(int id);
        Task<IEnumerable<Character>> GetAllAsync();
        Task AddAsync(Character character);
        Task UpdateAsync(Character character);
        Task DeleteAsync(int id);
        Task AddRangeAsync(IEnumerable<Character> characters);
    }
}
