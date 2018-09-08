using Bomholt.PetShop.Core.DomainService;
using Bomholt.PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomholt.Petshop.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        public OwnerRepository()
        {
            if (FakeDB.Owners.Count < 1)
            {
                InitDB();
            }
        }

        private void InitDB()
        {
            FakeDB.Owners.Add(new Owner()
            {
                ID = ++FakeDB.Owner_id,
                Name = "Lars Larsen",
                Address = "Tilbuds Gade 12",
                Email = "jegharetgodttilbudtildig@jydemail.dk"
                //Pets = {1,2} 
            });
            FakeDB.Owners.Add(new Owner()
            {
                ID = ++FakeDB.Owner_id,
                Name = "Jens Jensen",
                Address = "Titgens Gade 23",
                Email = "jjjensen@snydemail.dk"
                //Pets = { 3 }
            });
        }

        public bool CreateNew(Owner newOwner)
        {
            newOwner.ID = ++FakeDB.Owner_id;
            FakeDB.Owners.Add(newOwner);
            return true;
        }

        public bool DeleteById(int v)
        {
            var DelOwner = GetById(v);
            if (DelOwner != null)
            {
                FakeDB.Owners.Remove(DelOwner);
                return true;
            }
            return false;
        }

        public IEnumerable<Owner> GetAll()
        {
            return FakeDB.Owners;
        }

        public Owner GetById(int n)
        {
            foreach (var item in FakeDB.Owners)
            {
                if (item.ID == n)
                {
                    return item;
                }
            }
            return null;
        }

        public bool Update(Owner updatedOwner)
        {
            var UpOwner = GetById(updatedOwner.ID);
            if (UpOwner != null)
            {
                UpOwner.Name = updatedOwner.Name;
                UpOwner.Address = updatedOwner.Address;
                UpOwner.Email = updatedOwner.Email;
                UpOwner.Pets = updatedOwner.Pets;
                return true;
            }
            return false;
        }
    }
}
