using System;
using System.Collections.Generic;
using System.Text;

namespace PokeApp.BusinessLogic
{
    public class Pokemon
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public ISet<PokemonType> Types { get; set; }
    }
}
