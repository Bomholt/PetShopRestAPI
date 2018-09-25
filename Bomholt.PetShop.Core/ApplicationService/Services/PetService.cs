using System.Linq;
using System.Collections.Generic;
using Bomholt.PetShop.Core.DomainService;
using Bomholt.PetShop.Core.Entities;

namespace Bomholt.PetShop.Core.ApplicationService.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepo;

        public PetService(IPetRepository petRepo)
        {
            _petRepo = petRepo;
        }
        
        public Pet CreateNewPet(Pet newPet)
        {
           return _petRepo.CreateNewPet(newPet);
        }

        public Pet DeletePetById(int v)
        {
            return _petRepo.DeletePetById(v);
        }

        public List<Pet> Get5CheapestPets()
        {
            IEnumerable<Pet> allPets = _petRepo.GetAllPets();
            return allPets.OrderBy(pet => pet.Price).Take(5).ToList();
        }

        public List<Pet> GetAllPets()
        {
            return _petRepo.GetAllPets().ToList();
        }

        public Pet GetById(int v)
        {
            return _petRepo.GetById(v);
        }

        public List<Pet> SearchPetsByType(string searchType)
        {
            IEnumerable <Pet> allPets = _petRepo.GetAllPets();
            return allPets.Where(pet => pet.Type.Equals(searchType)).ToList();
        }

        public List<Pet> SortPetsByPrice()
        {
            IEnumerable<Pet> allPets = _petRepo.GetAllPets();
            return allPets.OrderBy(pet => pet.Price).ToList();
        }

        public Pet UpdatePet(Pet updatedPet)
        {
            return _petRepo.UpdatePet(updatedPet);
        }
    }
}
