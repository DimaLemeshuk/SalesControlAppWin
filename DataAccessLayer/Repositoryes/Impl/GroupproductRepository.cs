using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositoryes.Impl
{
    public class GroupproductRepository : BaseRepository<Groupproduct>
    {
        public GroupproductRepository(DbContext context) : base(context)
        {
        }
    }
}
