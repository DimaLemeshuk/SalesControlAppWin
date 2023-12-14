using BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAll();
        UserDTO Get(int id);
        IEnumerable<UserDTO> Find(Func<UserDTO, Boolean> predicate);
        void Create(UserDTO item);
        void Update(UserDTO item);
        bool Update(UserDTO item, string propertyName, object editedValue);
        void Delete(int id);
        void SaveChanges();
    }
}
