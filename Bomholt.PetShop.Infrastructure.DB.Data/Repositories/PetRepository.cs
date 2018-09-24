using Bomholt.PetShop.Core.DomainService;
using Bomholt.PetShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            newPet.Owner = _context.Owners.FirstOrDefault(o => o.ID == newPet.Owner.ID);
            Pet pt = _context.Add(newPet).Entity;
            _context.SaveChanges();
            return true;
        }

        public Pet DeletePetById(int v)
        {
            var petDeleted = _context.Remove<Pet>(new Pet {ID = v}).Entity;
            _context.SaveChanges();
            return petDeleted;
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return _context.Pets;
        }

        public Pet GetById(int v)
        {
            return _context.Pets.Include(p => p.Owner).FirstOrDefault(p => p.ID == v);
        }

        public bool UpdatePet(Pet updatedPet)
        {
            throw new NotImplementedException();
        }
    }
}
