using BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    internal interface ISupplierService
    {
        IEnumerable<SupplierDTO> GetAll();
        SupplierDTO Get(int id);
        IEnumerable<SupplierDTO> Find(Func<SupplierDTO, Boolean> predicate);
        void Create(SupplierDTO item);
        void Update(SupplierDTO item);
        public void Update(SupplierDTO item, string propertyName, object editedValue);
        void Delete(int id);
        void SaveChanges();
    }
}
