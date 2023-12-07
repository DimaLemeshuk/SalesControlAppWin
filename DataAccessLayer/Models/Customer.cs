using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Fathersname { get; set; }

    public string Phonenumber { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
