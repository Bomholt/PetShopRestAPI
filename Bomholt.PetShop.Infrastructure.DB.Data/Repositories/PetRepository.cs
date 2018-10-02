// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PetRepository.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the PetRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Bomholt.PetShop.Infrastructure.DB.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Bomholt.PetShop.Core.DomainService;
    using Bomholt.PetShop.Core.Entities;
    using Microsoft.EntityFrameworkCore;

    public class PetRepository : IPetRepository
    {
        private readonly PetShopContext _context;

        public PetRepository(PetShopContext context)
        {
            this._context = context;
        }

        public Pet CreateNewPet(Pet newPet)
        {
            newPet.Owner = _context.Owners.FirstOrDefault(o => o.Id == newPet.Owner.Id);
            Pet pt = _context.Add(newPet).Entity;
            _context.SaveChanges();
            return pt;
        }

        public Pet DeletePetById(int v)
        {
            var petDeleted = _context.Remove(new Pet {Id = v}).Entity;
            _context.SaveChanges();
            return petDeleted;
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return _context.Pets;
        }

        public Pet GetById(int v)
        {
            return _context.Pets.Include(p => p.Owner).FirstOrDefault(p => p.Id == v);
        }

        public Pet UpdatePet(Pet updatedPet)
        {
            updatedPet.Owner = _context.Owners.FirstOrDefault(o => o.Id == updatedPet.Owner.Id);
            Pet pt = _context.Update(updatedPet).Entity;
            _context.SaveChanges();
            return pt;
        }
    }
}
