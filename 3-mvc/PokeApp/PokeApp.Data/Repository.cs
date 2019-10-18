using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokeApp.BusinessLogic;

namespace PokeApp.Data
{
    public class Repository : IRepository
    {
        private readonly PokemonDbContext _context;

        public Repository(PokemonDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BusinessLogic.Pokemon>> GetAllPokemonAsync()
        {
            List<Pokemon> entities = await _context.Pokemon
                .Include(p => p.PokemonTypeJoins)
                    .ThenInclude(pt => pt.Type)
                .ToListAsync();

            return entities.Select(e => new BusinessLogic.Pokemon
            {
                Id = e.Id,
                Name = e.Name,
                Height = e.Height,
                Weight = e.Weight,
                Types = e.PokemonTypeJoins.Select(j => new BusinessLogic.PokemonType
                {
                    Id = j.Type.Id,
                    Name = j.Type.Name,
                }).ToHashSet()
            });
        }

        // if types are included, they must have IDs
        public async Task AddPokemonAsync(BusinessLogic.Pokemon pokemon)
        {
            var entity = new Pokemon
            {
                Name = pokemon.Name,
                Height = pokemon.Height,
                Weight = pokemon.Weight,
                PokemonTypeJoins = pokemon.Types.Select(t => new PokemonTypeJoin { TypeId = t.Id }).ToList()
            };

            // if name is already in use....
            if (await _context.Pokemon.AnyAsync(p => p.Name == entity.Name))
            {
                throw new InvalidOperationException("Already exists");
            }

            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BusinessLogic.PokemonType>> GetAllTypesAsync()
        {
            var entities = await _context.PokemonType.ToListAsync();
            return entities.Select(t => new BusinessLogic.PokemonType
            {
                 Id = t.Id,
                 Name = t.Name
            });
        }

        public async Task<BusinessLogic.PokemonType> GetTypeByNameAsync(string name)
        {
            var entity = await _context.PokemonType.FirstAsync(t => t.Name == name);

            return new BusinessLogic.PokemonType
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
