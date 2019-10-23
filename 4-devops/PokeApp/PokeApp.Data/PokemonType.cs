using System;
using System.Collections.Generic;
using System.Text;

namespace PokeApp.Data
{
    public class PokemonType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PokemonTypeJoin> PokemonTypeJoins { get; set; }
    }
}
