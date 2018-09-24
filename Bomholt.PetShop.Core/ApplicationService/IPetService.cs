using Bomholt.PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bomholt.PetShop.Core.ApplicationService
{
    public interface IPetService
    {
        //Read
        List<Pet> GetAllPets();
        Pet GetById(int v);
        Pet DeletePetById(int v);
        bool CreateNewPet(Pet newPet);
        bool UpdatePet(Pet updatedPet);
        List<Pet> SearchPetsByType(string searchType);
        List<Pet> SortPetsByPrice();
        List<Pet> Get5CheapestPets();
    }
}
