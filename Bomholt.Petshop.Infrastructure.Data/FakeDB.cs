using Bomholt.PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bomholt.Petshop.Infrastructure.Data
{
    public static class FakeDb
    {
        public static int OwnerId = 0;
        public static List<Owner> Owners = new List<Owner>();
    }
}
