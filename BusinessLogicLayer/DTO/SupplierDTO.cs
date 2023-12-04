using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.DTO;

public class SupplierDTO
{
    public int Id { get; set; }

    public string NameSuppliers { get; set; } = null!;

    public string Contacts { get; set; } = null!;

    public decimal Rating { get; set; }
}
