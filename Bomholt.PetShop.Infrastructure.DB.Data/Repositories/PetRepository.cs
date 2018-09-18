using Bomholt.PetShop.Core.DomainService;
using Bomholt.PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bomholt.PetShop.Infrastructure.DB.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetShopContext _context;

        public PetRepository(PetShopContext context)
        {
            _context = context;
        }

        public bool CreateNewPet(Pet newPet)
        {
            throw new NotImplementedException();
        }

        public bool DeletePetById(int v)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> GetAllPets()
        {
            throw new NotImplementedException();
        }

        public Pet GetById(int v)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePet(Pet updatedPet)
        {
            throw new NotImplementedException();
        }
    }
}
