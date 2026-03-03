using System;
using System.Collections.Generic;

namespace Api_Shoes_v1.RealModels;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Shoe> Shoes { get; set; } = new List<Shoe>();
}
