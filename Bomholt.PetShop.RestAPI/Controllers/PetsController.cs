using System.Collections.Generic;
using System.Data;
using Bomholt.PetShop.Core.ApplicationService;
using Bomholt.PetShop.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Bomholt.PetShop.RestAPI.Controllers
{
    [Route("api/[controller]")]
    public class PetsController : Controller
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        // GET api/pets
        [Authorize]
        [HttpGet]
        public IEnumerable<Pet> Get()
        {
            return _petService.GetAllPets();
        }

        // GET api/pets/5
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (id < 1)
            {
                return BadRequest("Id must be lager than zero!");
            }
            //Pet PetFound = _petService.GetById(id);
            Pet petFound = _petService.GetById(id);
            if (petFound == null)
            {
                return NotFound($"No pet with id {id} found!");
            }
            return Ok(petFound);
        }

        // POST api/pets
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Post([FromBody]Pet value)
        {
            Pet success = _petService.CreateNewPet(value);
            if (success != null)
            {
                return Json(success);
            }
            else
            {
                return NotFound("Something went wrong!");
            }
        }

        // PUT api/pets/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Pet value)
        {
            value.Id = id;
            
            if (id < 1)
            {
                return BadRequest("Id must be lager than zero!");
            }
            var success = _petService.UpdatePet(value);
            if (success != null)
            {
                return Json(success);
            }
            else
            {
                return NotFound($"No pet found with id {id}");
            }
            
        }

        // DELETE api/pets/5
        [Authorize(Roles = "Administrator")]
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
                return Json(success);
                return Ok($"Pet nr. {id} was deleted");
            }
            else
            {
                return NotFound($"No pet found with id {id}");
            }
        }
    }
}
