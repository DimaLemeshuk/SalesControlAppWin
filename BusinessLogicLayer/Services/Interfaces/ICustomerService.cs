using BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    internal interface ICustomerService
    {
        IEnumerable<CustomerDTO> GetAll();
        CustomerDTO Get(int id);
        IEnumerable<CustomerDTO> Find(Func<CustomerDTO, Boolean> predicate);
        void Create(CustomerDTO item);
        void Update(CustomerDTO item);
        bool Update(CustomerDTO item, string propertyName, object editedValue);
        void Delete(int id);
        void SaveChanges();
    }
}
