﻿using Bomholt.PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bomholt.PetShop.Core.ApplicationService
{
    public interface IOwnerService
    {
        List<Owner> GetAll();
        Owner GetById(int n);
        bool DeleteById(int v);
        Owner CreateNew(Owner newOwner);
        bool Update(Owner updatedOwner);
        Owner GetByIdWithPets(int id);
    }
}
