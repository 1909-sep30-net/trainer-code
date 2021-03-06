﻿using System;
using System.Collections.Generic;

namespace EfDemo.DataAccess.Entities
{
    public partial class Type
    {
        public Type()
        {
            PokemonType = new HashSet<PokemonType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PokemonType> PokemonType { get; set; }
    }
}
