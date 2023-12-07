using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.DTO;
public class SaleDTO
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int StoreId { get; set; }

    public DateTime DateTime { get; set; }

    public int Quantity { get; set; }

    public double SalesAmount { get; set; }

    public string Status { get; set; }

    public int CustomersId { get; set; }

    public virtual ProductDTO ProductDTO { get; set; } = null!;

    public virtual StoreDTO StoreDTO { get; set; } = null!;
    public virtual CustomerDTO CustomersDTO { get; set; } = null!;

}
