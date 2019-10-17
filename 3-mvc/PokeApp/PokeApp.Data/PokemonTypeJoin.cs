using System;
using System.Collections.Generic;
using System.Text;

namespace PokeApp.Data
{
    public class PokemonTypeJoin
    {
        public int PokemonId { get; set; }
        public int TypeId { get; set; }

        // navigation properties don't have to be virtual, that's just to allow for
        //  enabling lazy loading as an option
        public Pokemon Pokemon { get; set; }
        public PokemonType Type { get; set; }
    }
}
