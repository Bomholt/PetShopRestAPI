using Bomholt.PetShop.Core.DomainService;
using Bomholt.PetShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bomholt.PetShop.Infrastructure.DB.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly PetShopContext _context;

        public OwnerRepository(PetShopContext context)
        {
            _context = context;
        }

        public Owner CreateNew(Owner newOwner)
        {
            Owner ow = _context.Owners.Add(newOwner).Entity;
            _context.SaveChanges();
            return ow;
        }

        public Owner DeleteById(int v)
        {
            var ownerDeleted = _context.Remove(new Owner { Id = v }).Entity;
            _context.SaveChanges();
            return ownerDeleted;
        }

        public IEnumerable<Owner> GetAll()
        {
            return _context.Owners;
        }

        public Owner GetById(int n)
        {
            return _context.Owners.FirstOrDefault(o => o.Id == n);
        }

        public Owner GetByIdWithPets(int id)
        {
            return _context.Owners.Where(c => c.Id == id).Include(c => c.Pets).FirstOrDefault();
        }

        public Owner Update(Owner updatedOwner)
        {
            Owner ow = _context.Update(updatedOwner).Entity;
            _context.SaveChanges();
            return ow;
        }
    }
}
