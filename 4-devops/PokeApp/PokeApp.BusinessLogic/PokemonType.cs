using System.Collections.Generic;

namespace PokeApp.BusinessLogic
{
    public class PokemonType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ISet<Pokemon> Pokemon { get; set; }
    }
}
