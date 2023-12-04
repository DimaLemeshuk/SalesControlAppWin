using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.DTO;
public class ProductDTO
{
    public int Id { get; set; }

    public string NameProducts { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double Price { get; set; }

    public int AvailableQuantity { get; set; }

    public int SuplierId { get; set; }

    public int GroupProductsId { get; set; }

}
