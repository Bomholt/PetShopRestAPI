using System.Collections.Generic;

namespace Bomholt.PetShop.Core.DomainService
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Add(T entity);
        void Edit(T entity);
        void Remove(long id);
    }
}