using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitchenRestService.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KitchenRestService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgeItemsController : ControllerBase
    {
        private readonly Fridge _fridge;

        public FridgeItemsController(Fridge fridge)
        {
            _fridge = fridge ?? throw new ArgumentNullException(nameof(fridge));
        }

        // GET: api/FridgeItems
        [HttpGet]
        public IEnumerable<FridgeItem> Get()
        {
            // with a return type like this, ASP.NET choose status code "200" for success,
            // and serializes the return value for the response body.
            return _fridge.Items;
        }

        // GET: api/FridgeItems/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FridgeItems
        [HttpPost]
        public ActionResult Post([FromBody, Bind("Name,Expiration")] FridgeItem item)
        {
            // the client can't set the ID
            var newId = _fridge.Items.Max(i => i.Id) + 1;

            item.Id = newId;

            _fridge.Items.Add(item);

            // in a response to POST, you're supposed to
            // send "201 Created" status, with a Location header indicating
            // the URL of the newly created resource, and a representation of the
            // new resource in the body.
            return CreatedAtRoute("Get", new { Id = newId }, item);
        }

        // PUT: api/FridgeItems/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/FridgeItems/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
