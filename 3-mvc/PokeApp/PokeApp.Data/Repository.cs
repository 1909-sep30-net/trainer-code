﻿using System;
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

        public async Task AddPokemonAsync(BusinessLogic.Pokemon pokemon)
        {
            // missing types
            var entity = new Pokemon
            {
                Name = pokemon.Name,
                Height = pokemon.Height,
                Weight = pokemon.Weight
            };

            // if name is already in use....
            if (await _context.Pokemon.AnyAsync(p => p.Name == entity.Name))
            {
                throw new InvalidOperationException("Already exists");
            }

            _context.Add(entity);
            await _context.SaveChangesAsync();
        }
    }
}
