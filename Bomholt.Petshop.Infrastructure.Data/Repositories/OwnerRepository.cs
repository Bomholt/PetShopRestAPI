using Bomholt.PetShop.Core.DomainService;
using Bomholt.PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomholt.Petshop.Infrastructure.Data.Repositories
{
    public class OwnerRepository // : IOwnerRepository
    {
        public OwnerRepository()
        {
            if (FakeDb.Owners.Count < 1)
            {
                InitDb();
            }
        }

        private void InitDb()
        {
            FakeDb.Owners.Add(new Owner()
            {
                Id = ++FakeDb.OwnerId,
                Name = "Lars Larsen",
                Address = "Tilbuds Gade 12",
                Email = "jegharetgodttilbudtildig@jydemail.dk"
                //Pets = {1,2} 
            });
            FakeDb.Owners.Add(new Owner()
            {
                Id = ++FakeDb.OwnerId,
                Name = "Jens Jensen",
                Address = "Titgens Gade 23",
                Email = "jjjensen@snydemail.dk"
                //Pets = { 3 }
            });
        }

        public bool CreateNew(Owner newOwner)
        {
            newOwner.Id = ++FakeDb.OwnerId;
            FakeDb.Owners.Add(newOwner);
            return true;
        }

        public bool DeleteById(int v)
        {
            var delOwner = GetById(v);
            if (delOwner != null)
            {
                FakeDb.Owners.Remove(delOwner);
                return true;
            }
            return false;
        }

        public IEnumerable<Owner> GetAll()
        {
            return FakeDb.Owners;
        }

        public Owner GetById(int n)
        {
            foreach (var item in FakeDb.Owners)
            {
                if (item.Id == n)
                {
                    return item;
                }
            }
            return null;
        }

        public bool Update(Owner updatedOwner)
        {
            var upOwner = GetById(updatedOwner.Id);
            if (upOwner != null)
            {
                upOwner.Name = updatedOwner.Name;
                upOwner.Address = updatedOwner.Address;
                upOwner.Email = updatedOwner.Email;
                upOwner.Pets = updatedOwner.Pets;
                return true;
            }
            return false;
        }
        
        public Owner GetByIdWithPets(int id)
        {
            throw new NotImplementedException();
        }
    }
}
