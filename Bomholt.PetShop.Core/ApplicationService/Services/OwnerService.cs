using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bomholt.PetShop.Core.DomainService;
using Bomholt.PetShop.Core.Entities;

namespace Bomholt.PetShop.Core.ApplicationService.Services
{
    public class OwnerService : IOwnerService
    {
        private IOwnerRepository _ownerRepo;

        public OwnerService(IOwnerRepository ownerRepo)
        {
            _ownerRepo = ownerRepo;
        }

        public Owner CreateNew(Owner newOwner)
        {
            return _ownerRepo.CreateNew(newOwner);
        }

        public bool DeleteById(int v)
        {
            return _ownerRepo.DeleteById(v);
        }

        public List<Owner> GetAll()
        {
            return _ownerRepo.GetAll().ToList();
        }

        public Owner GetById(int n)
        {
            return _ownerRepo.GetById(n);
        }

        public Owner GetByIdWithPets(int id)
        {
            return _ownerRepo.GetByIdWithPets(id);
        }

        public bool Update(Owner updatedOwner)
        {
            return _ownerRepo.Update(updatedOwner);
        }
    }
}
