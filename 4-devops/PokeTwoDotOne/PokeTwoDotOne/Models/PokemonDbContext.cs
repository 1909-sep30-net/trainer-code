using Microsoft.EntityFrameworkCore;

namespace PokeApp.Data.Models
{
    public class PokemonDbContext : DbContext
    {
        public PokemonDbContext()
        { }

        public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base(options)
        { }

        public DbSet<Pokemon> Pokemon { get; set; }
    }
}
