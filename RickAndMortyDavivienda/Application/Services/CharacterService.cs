using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class CharacterService
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterService(ICharacterRepository CharacterRepository)
        {
            _characterRepository = CharacterRepository;
        }

        public async Task<Character> GetByIdAsync(int id)
        {
            var character = await _characterRepository.GetByIdAsync(id);
            
            return character;
        }

        public async Task<IEnumerable<Character>> GetAllAsync()
        {
            return await _characterRepository.GetAllAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Character> locations)
        {
            await _characterRepository.AddRangeAsync(locations);
        }

        public async Task AddAsync(Character character)
        {
            await _characterRepository.AddAsync(character);
        }

        public async Task DeleteAsync(int id)
        {
            await _characterRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(Character character)
        {
            await _characterRepository.UpdateAsync(character);
        }        
    }
}
