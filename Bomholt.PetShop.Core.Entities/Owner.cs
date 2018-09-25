using System;
using System.Collections.Generic;
using System.Text;

namespace Bomholt.PetShop.Core.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address{ get; set; }
        public string Email { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
