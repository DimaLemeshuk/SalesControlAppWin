using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositoryes.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate, int pageNumber, int pageSize);
        void Create(T item);
        void Update(T item);
        public void Update(T item, string propertyName, object editedValue);
        void Delete(int id);

        void SaveChanges();
    }
}
