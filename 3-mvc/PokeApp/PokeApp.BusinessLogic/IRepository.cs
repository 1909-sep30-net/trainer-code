using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokeApp.BusinessLogic
{
    public interface IRepository
    {
        // includes types
        Task<IEnumerable<Pokemon>> GetAllPokemonAsync();

        Task AddPokemonAsync();
    }
}
