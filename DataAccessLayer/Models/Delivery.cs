using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Delivery
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public DateTime DateTime { get; set; }

    public int Quantity { get; set; }

    public double DeliveryCost { get; set; }

    public virtual Product Product { get; set; } = null!;
}
