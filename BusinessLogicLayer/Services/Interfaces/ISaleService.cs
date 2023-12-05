using BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    internal interface ISaleService
    {
        IEnumerable<SaleDTO> GetAll();
        SaleDTO Get(int id);
        IEnumerable<SaleDTO> Find(Func<SaleDTO, Boolean> predicate);
        void Create(SaleDTO item);
        void Update(SaleDTO item);
        public void Update(SaleDTO item, string propertyName, object editedValue);
        void Delete(int id);
        void SaveChanges();
    }
}
