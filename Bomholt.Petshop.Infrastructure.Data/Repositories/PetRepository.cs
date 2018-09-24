using Bomholt.PetShop.Core.DomainService;
using Bomholt.PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bomholt.Petshop.Infrastructure.Data.Repositories
{
    public class PetRepository // : IPetRepository

    {
        private static int id = 1;
        public static IEnumerable<Pet> _pets = new List<Pet>();

        public static void InitDB()
        {
            var temp = _pets.ToList();
            temp.Add(new Pet() { Owner = new Owner() { ID = 1 }, Name = "Iben", Type = "Cat", Color = "Black", Birthdate = new DateTime(2011, 05, 15), PreviousOwner = "Hans Hansen", Price = 100, ID = id++ });
            temp.Add(new Pet() { Owner = new Owner() { ID = 1 }, Name = "Lars", Type = "Pecker", Color = "Pink", Birthdate = new DateTime(2017, 11, 22), PreviousOwner = "Birthe Hansen", Price = 1000, ID = id++ });
            temp.Add(new Pet() { Owner = new Owner() { ID = 2 }, Name = "Ralf", Type = "Gyraf", Color = "White", Birthdate = new DateTime(2015, 01, 09), PreviousOwner = "Hans Ipsen", Price = 150.5, ID = id++ });
            temp.Add(new Pet() { Owner = new Owner() { ID = 2 }, Name = "Garfield", Type = "Dolphin", Color = "Orange", Birthdate = new DateTime(2018, 09, 05), PreviousOwner = "Jens Jensen", Price = 1559.95, ID = id++ });
            _pets = temp;
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return _pets;
        }

        public bool DeletePetById(int v)
        {
            bool success = false;
            var tempList = _pets.ToList();
            Pet DelPet = null;
            foreach (var item in tempList)
            {
                if (item.ID == v)
                {
                    DelPet = item;
                    success = true;
                    break;
                }
            }
            if (DelPet == null)
            {
                return false;
            }
            tempList.Remove(DelPet);
            _pets = tempList;
            return success;
        }

        public bool CreateNewPet(Pet newPet)
        {
            var temp = _pets.ToList();
            newPet.ID = id++;
            temp.Add(newPet);
            _pets = temp;
            return true;
        }

        public bool UpdatePet(Pet updatedPet)
        {
            var tempList = _pets.ToList();
            Pet PetUpdate = null;
            foreach (var item in tempList)
            {
                if (item.ID == updatedPet.ID)
                {
                    PetUpdate = item;
                    break;
                }
            }
            if (PetUpdate == null)
            {
                return false;
            }
            PetUpdate.Name = updatedPet.Name;
            PetUpdate.Type = updatedPet.Type;
            PetUpdate.Color = updatedPet.Color;
            PetUpdate.PreviousOwner = updatedPet.PreviousOwner;
            PetUpdate.Birthdate = updatedPet.Birthdate;
            PetUpdate.Solddate = updatedPet.Solddate;
            PetUpdate.Price = updatedPet.Price;
            _pets = tempList;
            return true;
        }

        public Pet GetById(int v)
        {
            var tempList = _pets.ToList();
            Pet TehPet = null;
            foreach (var item in tempList)
            {
                if (item.ID == v)
                {
                    TehPet = item;
                    break;
                }
            }
            return TehPet;
        }
    }
}
