using System;
using System.Collections.Generic;

namespace Api_Shoes_v1.RealModels;

public partial class Role
{
    public int Idrol { get; set; }

    public string? Tiporol { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
