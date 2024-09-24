using Microsoft.EntityFrameworkCore;
using PokedexAPI.Context;
using PokedexAPI.Repositories.Interface;
using PokedexAPI.Models;

namespace PokedexAPI.Repositories {
    public class PokemonRepository : IPokemonRepository {
        private readonly AppDbContext _context;

        public PokemonRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Pokemon>> GetAllAsync() {
            return await _context.Pokemons.ToListAsync();
        }

        public async Task<Pokemon> GetByIdAsync(int id) {
            return await _context.Pokemons.FindAsync(id);
        }

        public async Task AddAsync(Pokemon pokemon) {
            await _context.Pokemons.AddAsync(pokemon);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pokemon pokemon) {
            _context.Pokemons.Update(pokemon);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id) {
            var pokemon = await GetByIdAsync(id);
            if (pokemon != null) {
                _context.Pokemons.Remove(pokemon);
                await _context.SaveChangesAsync();
            }
        }
    }
}
