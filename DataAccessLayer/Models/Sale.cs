using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Sale
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int StoreId { get; set; }

    public DateTime DateTime { get; set; }

    public int Quantity { get; set; }

    public double SalesAmount { get; set; }

    public string Status { get; set; } = null!;

    public int CustomersId { get; set; }

    public string Address { get; set; } = null!;
    public string Payment { get; set; } = null!;

    public string? TTN { get; set; } = null!;

    public virtual Customer Customers { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
