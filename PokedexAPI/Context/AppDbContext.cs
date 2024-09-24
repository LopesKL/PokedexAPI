using Microsoft.EntityFrameworkCore;
using PokedexAPI.Models;

namespace PokedexAPI.Context {
    public class AppDbContext : DbContext {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Pokemon> Pokemons { get; set; }

    }
}


