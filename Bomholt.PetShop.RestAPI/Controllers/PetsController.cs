using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public Pet Get(int id)
        {
            return _petService.GetById(id);
        }

        // POST api/pets
        [HttpPost]
        public void Post([FromBody]Pet value)
        {
            bool success = _petService.CreateNewPet(value);
        }

        // PUT api/pets/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Pet value)
        {
            value.ID = id;
            bool success = _petService.UpdatePet(value);
        }

        // DELETE api/pets/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _petService.DeletePetById(id);
        }
    }
}
