using BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    internal interface IProductService
    {
        IEnumerable<ProductDTO> GetAll();
        ProductDTO Get(int id);
        IEnumerable<ProductDTO> Find(Func<ProductDTO, Boolean> predicate);
        void Create(ProductDTO item);
        void Update(ProductDTO item);
        void Delete(int id);
        void SaveChanges();
    }
}
