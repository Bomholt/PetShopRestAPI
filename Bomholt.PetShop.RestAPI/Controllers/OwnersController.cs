using System.Collections.Generic;
using Bomholt.PetShop.Core.ApplicationService;
using Bomholt.PetShop.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Bomholt.PetShop.RestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Owners")]
    public class OwnersController : Controller
    {
        private IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            this._ownerService = ownerService;
        }

        // GET: api/Owners
        [HttpGet]
        public IEnumerable<Owner> Get()
        {
            return _ownerService.GetAll();
        }

        // GET: api/Owners/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            if (id < 1)
            {
                return BadRequest("Id must be larger than zero!");
            }
            //Owner OwnerFound = _ownerService.GetById(id);
            Owner OwnerFound = _ownerService.GetByIdWithPets(id);
            if (OwnerFound == null)
            {
                return NotFound($"No owner with id {id} found!");
            }
            return Ok(OwnerFound);
        }
        
        // POST: api/Owners
        [HttpPost]
        public ActionResult Post([FromBody]Owner value)
        {
            Owner success = _ownerService.CreateNew(value);
            if (success!= null)
            {
                return Ok($"Owner {success} was successfully created");
            }
            else
            {
                return NotFound("Something went wrong!");
            }
        }
        
        // PUT: api/Owners/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Owner value)
        {
            value.ID = id;
            if (id < 1)
            {
                return BadRequest("Id must be lager than zero!");
            }
            bool success = _ownerService.Update(value);
            if (success)
            {
                return Ok($"Owner nr. {id} was updated");
            }
            else
            {
                return NotFound($"No owner found with id {id}");
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest("Id must be lager than zero!");
            }
            bool success = _ownerService.DeleteById(id);
            if (success)
            {
                return Ok("Owner nr. {id} was deleted");
            }
            else
            {
                return NotFound("No owner found with id {id}");
            }
        }
    }
}
