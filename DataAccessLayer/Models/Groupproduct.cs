using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Groupproduct
{
    public int Id { get; set; }

    public string NameGroupproducts { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
