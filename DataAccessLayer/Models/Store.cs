using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Store
{
    public int Id { get; set; }

    public string SocialNetwork { get; set; } = null!;

    public string NameStores { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
