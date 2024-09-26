using Microsoft.AspNetCore.Mvc;
using PokedexAPI.Repositories.Interface;
using PokedexAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using PokedexAPI.Context;
using Microsoft.EntityFrameworkCore;

namespace PokedexAPI.Controllers {


    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase {
        private readonly AppDbContext _context;

        public PokemonController(AppDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pokemon>>> GetPokemons() {
            return await _context.Pokemons.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult<Pokemon>> PostPokemon(Pokemon pokemon) {
            if (pokemon == null) {
                return BadRequest();
            }

            _context.Pokemons.Add(pokemon);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPokemons), new { id = pokemon.Id }, pokemon);
        }


        [HttpPut]
        public async Task<IActionResult> PutPokemon(int numeroPokedex, Pokemon pokemon) {

            _context.Entry(pokemon).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!PokemonExists(numeroPokedex)) {
                    return NotFound("Pokémon não encontrado.");
                }
                else {
                    throw;
                }
            }

            return NoContent(); 
        }

        private bool PokemonExists(int numeroPokedex) {
            return _context.Pokemons.Any(e => e.Id == numeroPokedex);
        }


        [HttpDelete]
        public IActionResult Delete([FromBody] Pokemon pokemonToDelete) {

            if (pokemonToDelete == null || pokemonToDelete.Id <= 0) {
                return BadRequest("Pokémon inválido.");
            }

            var pokemon = _context.Pokemons.FirstOrDefault(p => p.Id == pokemonToDelete.Id);

            if (pokemon == null) {
                return NotFound("Pokémon não encontrado.");
            }

            _context.Pokemons.Remove(pokemon);

            _context.SaveChanges();

            return Ok("Pokémon excluído com sucesso.");
        }


    }

}

