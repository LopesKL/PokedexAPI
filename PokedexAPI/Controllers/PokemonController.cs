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

            // Método GET (por exemplo)
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Pokemon>>> GetPokemons() {
                return await _context.Pokemons.ToListAsync();
            }

            // Método POST
            [HttpPost]
            public async Task<ActionResult<Pokemon>> PostPokemon(Pokemon pokemon) {
                if (pokemon == null) {
                    return BadRequest();
                }

                _context.Pokemons.Add(pokemon);
                await _context.SaveChangesAsync();

                // Retorna o novo item criado, com o status HTTP 201 (Created)
                return CreatedAtAction(nameof(GetPokemons), new { id = pokemon.Id }, pokemon);
            }
        }

    }

