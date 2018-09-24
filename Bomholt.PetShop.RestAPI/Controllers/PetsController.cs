using System.Collections.Generic;
using Bomholt.PetShop.Core.ApplicationService;
using Bomholt.PetShop.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Bomholt.PetShop.RestAPI.Controllers
{
    [Route("api/[controller]")]
    public class PetsController : Controller
    {
        private IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        // GET api/pets
        [HttpGet]
        public IEnumerable<Pet> Get()
        {
            return _petService.GetAllPets();
        }

        // GET api/pets/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (id < 1)
            {
                return BadRequest("Id must be lager than zero!");
            }
            //Pet PetFound = _petService.GetById(id);
            Pet PetFound = _petService.GetById(id);
            if (PetFound == null)
            {
                return NotFound($"No pet with id {id} found!");
            }
            return Ok(PetFound);
        }

        // POST api/pets
        [HttpPost]
        public ActionResult Post([FromBody]Pet value)
        {
            bool success = _petService.CreateNewPet(value);
            if (success)
            {
                return Ok($"Pet {value} was created");
            }
            else
            {
                return NotFound("Something went wrong!");
            }
        }

        // PUT api/pets/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Pet value)
        {
            value.ID = id;
            if (id < 1)
            {
                return BadRequest("Id must be lager than zero!");
            }
            bool success = _petService.UpdatePet(value);
            if (success)
            {
                return Ok($"Pet nr. {id} was updated");
            }
            else
            {
                return NotFound($"No pet found with id {id}");
            }
        }

        // DELETE api/pets/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest("Id must be lager than zero!");
            }
            Pet success = _petService.DeletePetById(id);
            if (success != null)
            {
                return Ok($"Pet nr. {id} was deleted");
            }
            else
            {
                return NotFound($"No pet found with id {id}");
            }
        }
    }
}
