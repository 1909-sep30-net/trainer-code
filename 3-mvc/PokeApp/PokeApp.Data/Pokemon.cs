using System;
using System.Collections.Generic;
using System.Text;

namespace PokeApp.Data
{
    public class Pokemon
    {
        public int Id { get; set; } // by convention automatically assigned as PK
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        // if i don't need the foreign key properties
        // if i'm not going to use them.
        // (if i don't type them out, EF does add them under the hood as "shadow properties")

        // if i don't need one of the two navigation properties per relationship
        // i can leave it out.

        public ICollection<PokemonTypeJoin> PokemonTypeJoins { get; set; }
    }
}
