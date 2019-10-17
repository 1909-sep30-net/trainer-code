using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeApp.BusinessLogic;
using PokeApp.WebApp.Models;

namespace PokeApp.WebApp.Controllers
{
    public class PokemonController : Controller
    {
        private readonly IRepository _repository;

        public PokemonController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: Pokemon
        public async Task<ActionResult> Index()
        {
            // to get the pokemon, i need some IRepository.
            // so, instead of just writing "new Repository()",
            // i will use "constructor injection pattern"
            IEnumerable<Pokemon> pokemon = await _repository.GetAllPokemonAsync();

            var viewModels = pokemon.Select(p => new PokemonViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Height = p.Height,
                Weight = p.Weight,
                Types = p.Types.Select(t => t.Name).ToList()
            });

            return View(viewModels);
        }

        // GET: Pokemon/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pokemon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pokemon/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PokemonViewModel viewModel)
        {
            try
            {
                // just like how strongly typed view is the better version
                // of weakly-typed view, we have the option
                // of "model binding" instead of this FormCollection.

                //var pokemon = new Pokemon
                //{
                //    Name = collection["Name"],
                //    Height = int.Parse(collection["Height"]),
                //    Weight = int.Parse(collection["Weight"]),
                //    Types = 
                //}

                // ModelState works with model binding to give us automatic 
                // server-side validation of any of those attributes on the model class.
                // (e.g. Required, Range, RegularExpression)
                if (!ModelState.IsValid)
                {
                    // server-side validation failure, return a new form to the
                    // user, but for convenience, fill in his previous (wrong) data
                    return View(viewModel);
                    // also, if ModelState contains errors when we render that form,
                    // the validation tag helpers will get filled in with error messages
                }

                var pokemon = new Pokemon
                {
                    Id = viewModel.Id,
                    Name = viewModel.Name,
                    Height = viewModel.Height,
                    Weight = viewModel.Weight
                    // missing types!
                };

                // missing exception handling
                await _repository.AddPokemonAsync(pokemon);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pokemon/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pokemon/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pokemon/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pokemon/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
