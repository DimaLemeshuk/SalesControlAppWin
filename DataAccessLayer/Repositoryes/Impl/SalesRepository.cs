using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositoryes.Impl
{
    public class SalesRepository : BaseRepository<Sale>
    {
        public SalesRepository() : base()
        {
        }
    }


}
