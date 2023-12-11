using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Product
{
    public int Id { get; set; }

    public string NameProducts { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double Price { get; set; }

    public int AvailableQuantity { get; set; }

    public int SuplierId { get; set; }

    public int GroupProductsId { get; set; }

    public string Address { get; set; } = null!;

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual Groupproduct GroupProducts { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual Supplier Suplier { get; set; } = null!;
}
