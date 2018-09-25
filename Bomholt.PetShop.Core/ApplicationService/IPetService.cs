using Bomholt.PetShop.Core.Entities;
using System.Collections.Generic;

namespace Bomholt.PetShop.Core.ApplicationService
{
    public interface IPetService
    {
        //Read
        List<Pet> GetAllPets();
        Pet GetById(int v);
        Pet DeletePetById(int v);
        Pet CreateNewPet(Pet newPet);
        Pet UpdatePet(Pet updatedPet);
        List<Pet> SearchPetsByType(string searchType);
        List<Pet> SortPetsByPrice();
        List<Pet> Get5CheapestPets();
    }
}
