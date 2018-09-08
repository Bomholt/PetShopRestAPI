using Bomholt.PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bomholt.Petshop.Infrastructure.Data
{
    public static class FakeDB
    {
        public static int Owner_id = 0;
        public static List<Owner> Owners = new List<Owner>();
    }
}
