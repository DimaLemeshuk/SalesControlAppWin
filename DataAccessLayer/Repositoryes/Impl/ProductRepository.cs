using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositoryes.Impl
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository() : base()
        {
        }

        public IEnumerable<Product> GetAll()
        {
            using (var context = new StoresDbContext())
            {
                return context.Products
                .Include(e => e.Suplier)
                .Include(e => e.GroupProducts)
                .ToList();
            }
        }
    }
}