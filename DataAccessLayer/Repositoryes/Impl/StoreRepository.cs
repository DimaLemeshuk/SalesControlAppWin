using DataAccessLayer.Models;
using DataAccessLayer.Repositoryes.Impl;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositoryes.Impl
{
    public class StoreRepository : BaseRepository<Store>
    {
        public StoreRepository() : base()
        {
        }
    }
}

