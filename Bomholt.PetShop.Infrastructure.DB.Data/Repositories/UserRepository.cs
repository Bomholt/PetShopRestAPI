using System.Collections.Generic;
using System.Linq;
using Bomholt.PetShop.Core.DomainService;
using Bomholt.PetShop.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bomholt.PetShop.Infrastructure.DB.Data.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly PetShopContext _context;

        public UserRepository(PetShopContext context)
        {
            this._context = context;
        }

        public void Add(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Edit(User entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public User Get(long id)
        {
            return _context.Users.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Remove(long id)
        {
            var item = _context.Users.FirstOrDefault(b => b.Id == id);
            _context.Users.Remove(item);
            _context.SaveChanges();
        }
    }
}