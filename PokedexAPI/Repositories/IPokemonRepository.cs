using PokedexAPI.Models;

namespace PokedexAPI.Repositories.Interface {
    public interface IPokemonRepository {
        // Defina os métodos que o repositório deve implementar
        Task<IEnumerable<Pokemon>> GetAllAsync();
        Task<Pokemon> GetByIdAsync(int id);
        Task AddAsync(Pokemon pokemon);
        Task UpdateAsync(Pokemon pokemon);
        Task DeleteAsync(int id);
    }
}
