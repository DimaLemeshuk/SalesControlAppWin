using BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IDeliveryService
    {
        IEnumerable<GroupproductDTO> GetAll();
        GroupproductDTO Get(int id);
        IEnumerable<GroupproductDTO> Find(Func<GroupproductDTO, Boolean> predicate);
        void Create(GroupproductDTO item);
        void Update(GroupproductDTO item);
        void Delete(int id);
        void SaveChanges();
    }
}
