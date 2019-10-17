using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PokeApp.WebApp.Models
{
    // in MVC, the "model" doesn't depend on the view.....
    // but MVC views do need a model that has all the data they need to display
        // sometimes those needs clash.
    // so often we will make a new model class that is tightly coupled to the view,
    // gives all the things that view needs.
    // in this case, we call that new class a view model.
    public class PokemonViewModel
    {
        [DisplayName("ID")] // this one is associated with the Html.DisplayNameFor helper
        public int Id { get; set; }

        //[DisplayFormat(] // there are attributes like Display and DisplayFormat
        // to modify here in this one place how values in this property will be displayed in some view
        // (when we use the Html.DisplayFor HTML helper!)
        public string Name { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public List<string> Types { get; set; }
    }
}
