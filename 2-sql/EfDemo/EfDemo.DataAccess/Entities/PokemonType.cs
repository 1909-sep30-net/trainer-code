﻿using System;
using System.Collections.Generic;

namespace EfDemo.DataAccess.Entities
{
    public partial class PokemonType
    {
        public int Id { get; set; }
        public int PokemonId { get; set; }
        public int TypeId { get; set; }

        public virtual Pokemon Pokemon { get; set; }
        public virtual Type Type { get; set; }
    }
}
