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
        IEnumerable<DeliveryDTO> GetAll();
        DeliveryDTO Get(int id);
        IEnumerable<DeliveryDTO> Find(Func<DeliveryDTO, Boolean> predicate);
        void Create(DeliveryDTO item);
        void Update(DeliveryDTO item);
        void Delete(int id);
        void SaveChange();
    }
}
