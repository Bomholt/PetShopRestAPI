using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bomholt.PetShop.Core.DomainService;
using Bomholt.PetShop.Core.Entities;

namespace Bomholt.PetShop.Core.ApplicationService.Services
{
    public class OwnerService : IOwnerService
    {
        private IOwnerRepository _ownerRepo;
        private IPetRepository _petRepo;

        public OwnerService(IOwnerRepository ownerRepo, IPetRepository petRepository)
        {
            _ownerRepo = ownerRepo;
            _petRepo = petRepository;
        }

        public bool CreateNew(Owner newOwner)
        {
            return _ownerRepo.CreateNew(newOwner);
        }

        public bool DeleteById(int v)
        {
            return _ownerRepo.DeleteById(v);
        }

        public List<Owner> GetAll()
        {
            return _ownerRepo.GetAll().ToList();
        }

        public Owner GetById(int n)
        {
            return _ownerRepo.GetById(n);
        }

        public Owner GetByIdWithPets(int id)
        {
            Owner owner = _ownerRepo.GetById(id);
            owner.Pets = _petRepo.GetAllPets().Where(pet => pet.Owner.ID == owner.ID).ToList();
            //customer.Orders = _orderRepo.ReadAll()
            //    .Where(order => order.Customer.Id == customer.Id)
            //    .ToList();
            return owner;
        }

        public bool Update(Owner updatedOwner)
        {
            return _ownerRepo.Update(updatedOwner);
        }
    }
}
