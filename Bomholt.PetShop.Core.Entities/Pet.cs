﻿using System;
using System.Collections.Generic;

namespace Bomholt.PetShop.Core.Entities
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime Solddate { get; set; }
        public string PreviousOwner { get; set; }
        public double Price { get; set; }
        public Owner Owner { get; set; }
        //public IList <PetColor> PetColors { get; set; }
    }
}
