using BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    internal interface IGroupproductService
    {
        IEnumerable<GroupproductDTO> GetAll();
        GroupproductDTO Get(int id);
        IEnumerable<GroupproductDTO> Find(Func<GroupproductDTO, Boolean> predicate);
        void Create(GroupproductDTO item);
        void Update(GroupproductDTO item);
        public void Update(GroupproductDTO item, string propertyName, object editedValue);
        void Delete(int id);
        void SaveChanges();
    }
}
