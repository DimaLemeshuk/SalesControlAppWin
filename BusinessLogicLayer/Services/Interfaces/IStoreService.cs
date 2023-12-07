using BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    internal interface IStoreService
    {
        IEnumerable<StoreDTO> GetAll();
        StoreDTO Get(int id);
        IEnumerable<StoreDTO> Find(Func<StoreDTO, Boolean> predicate);
        void Create(StoreDTO item);
        void Update(StoreDTO item);
        bool Update(StoreDTO item, string propertyName, object editedValue);
        void Delete(int id);
        void SaveChanges();
    }
}
