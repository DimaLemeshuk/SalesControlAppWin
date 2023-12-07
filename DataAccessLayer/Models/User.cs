using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;
public partial class User
{
    public int Iduser { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Type { get; set; } = null!;
}
