using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Supplier
{
    public int Id { get; set; }

    public string NameSuppliers { get; set; } = null!;

    public string Contacts { get; set; } = null!;

    public decimal Rating { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
