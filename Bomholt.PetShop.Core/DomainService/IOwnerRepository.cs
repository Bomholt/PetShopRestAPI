using Bomholt.PetShop.Core.Entities;
using System.Collections.Generic;

namespace Bomholt.PetShop.Core.DomainService
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();
        Owner GetById(int n);
        bool DeleteById(int v);
        Owner CreateNew(Owner newOwner);
        bool Update(Owner updatedOwner);
        Owner GetByIdWithPets(int id);
    }
}
