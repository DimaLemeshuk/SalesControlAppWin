using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositoryes.Impl
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository() : base()
        {
        }
    }
}