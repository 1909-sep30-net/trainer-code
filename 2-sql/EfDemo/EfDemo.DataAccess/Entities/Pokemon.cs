using System;
using System.Collections.Generic;

namespace EfDemo.DataAccess.Entities
{
    public partial class Pokemon
    {
        public Pokemon()
        {
            PokemonType = new HashSet<PokemonType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        public virtual ICollection<PokemonType> PokemonType { get; set; }
    }
}
