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

}
