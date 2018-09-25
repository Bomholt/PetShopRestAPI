using Bomholt.PetShop.Core.DomainService;
using Bomholt.PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bomholt.Petshop.Infrastructure.Data.Repositories
{
    public class PetRepository // : IPetRepository

    {
        private static int _id = 1;
        public static IEnumerable<Pet> Pets = new List<Pet>();

        public static void InitDb()
        {
            var temp = Pets.ToList();
            temp.Add(new Pet() { Owner = new Owner() { Id = 1 }, Name = "Iben", Type = "Cat", Color = "Black", Birthdate = new DateTime(2011, 05, 15), PreviousOwner = "Hans Hansen", Price = 100, Id = _id++ });
            temp.Add(new Pet() { Owner = new Owner() { Id = 1 }, Name = "Lars", Type = "Pecker", Color = "Pink", Birthdate = new DateTime(2017, 11, 22), PreviousOwner = "Birthe Hansen", Price = 1000, Id = _id++ });
            temp.Add(new Pet() { Owner = new Owner() { Id = 2 }, Name = "Ralf", Type = "Gyraf", Color = "White", Birthdate = new DateTime(2015, 01, 09), PreviousOwner = "Hans Ipsen", Price = 150.5, Id = _id++ });
            temp.Add(new Pet() { Owner = new Owner() { Id = 2 }, Name = "Garfield", Type = "Dolphin", Color = "Orange", Birthdate = new DateTime(2018, 09, 05), PreviousOwner = "Jens Jensen", Price = 1559.95, Id = _id++ });
            Pets = temp;
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return Pets;
        }

        public bool DeletePetById(int v)
        {
            bool success = false;
            var tempList = Pets.ToList();
            Pet delPet = null;
            foreach (var item in tempList)
            {
                if (item.Id == v)
                {
                    delPet = item;
                    success = true;
                    break;
                }
            }
            if (delPet == null)
            {
                return false;
            }
            tempList.Remove(delPet);
            Pets = tempList;
            return success;
        }

        public bool CreateNewPet(Pet newPet)
        {
            var temp = Pets.ToList();
            newPet.Id = _id++;
            temp.Add(newPet);
            Pets = temp;
            return true;
        }

        public bool UpdatePet(Pet updatedPet)
        {
            var tempList = Pets.ToList();
            Pet petUpdate = null;
            foreach (var item in tempList)
            {
                if (item.Id == updatedPet.Id)
                {
                    petUpdate = item;
                    break;
                }
            }
            if (petUpdate == null)
            {
                return false;
            }
            petUpdate.Name = updatedPet.Name;
            petUpdate.Type = updatedPet.Type;
            petUpdate.Color = updatedPet.Color;
            petUpdate.PreviousOwner = updatedPet.PreviousOwner;
            petUpdate.Birthdate = updatedPet.Birthdate;
            petUpdate.Solddate = updatedPet.Solddate;
            petUpdate.Price = updatedPet.Price;
            Pets = tempList;
            return true;
        }

        public Pet GetById(int v)
        {
            var tempList = Pets.ToList();
            Pet tehPet = null;
            foreach (var item in tempList)
            {
                if (item.Id == v)
                {
                    tehPet = item;
                    break;
                }
            }
            return tehPet;
        }
    }
}
