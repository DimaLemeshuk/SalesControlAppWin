using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string? Fathersname { get; set; }

        public string Phonenumber { get; set; } = null!;
    }
}
