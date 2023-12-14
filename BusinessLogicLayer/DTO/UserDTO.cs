using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class UserDTO
    {
        public int Iduser { get; set; }

        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Type { get; set; } = null!;
    }
}
