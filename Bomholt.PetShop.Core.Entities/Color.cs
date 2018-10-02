using System;
using System.Collections.Generic;
using System.Text;

namespace Bomholt.PetShop.Core.Entities
{
    public class Color
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
        public ICollection<PetColor> PetColor { get; set; }
    }
}
