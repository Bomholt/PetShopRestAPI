using Bomholt.PetShop.Core.DomainService;
using Bomholt.PetShop.Core.Entities;
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
            Owner Ow = _context.Owners.Add(newOwner).Entity;
            _context.SaveChanges();
            return Ow;
        }

        public bool DeleteById(int v)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Owner> GetAll()
        {
            return _context.Owners;
        }

        public Owner GetById(int n)
        {
            return _context.Owners.FirstOrDefault(o => o.ID == n);
        }

        public bool Update(Owner updatedOwner)
        {
            throw new NotImplementedException();
        }
    }
}
