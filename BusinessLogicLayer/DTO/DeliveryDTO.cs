﻿using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.DTO;

public class DeliveryDTO
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public DateTime? DateTime { get; set; }

    public int Quantity { get; set; }

    public double DeliveryCost { get; set; }

    public string Status { get; set; }

    public DateTime? ScheduledDateTime { get; set; }

    public virtual ProductDTO ProductDTO { get; set; } = null!;

}
