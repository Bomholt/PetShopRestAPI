using Bomholt.PetShop.Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Bomholt.PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        IEnumerable<Pet> GetAllPets();
        Pet GetById(int v);
        Pet DeletePetById(int v);
        bool CreateNewPet(Pet newPet);
        bool UpdatePet(Pet updatedPet);
    }
}
