using Bomholt.PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bomholt.PetShop.Core.DomainService
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();
        Owner GetById(int n);
        bool DeleteById(int v);
        bool CreateNew(Owner newOwner);
        bool Update(Owner updatedOwner);
    }
}
