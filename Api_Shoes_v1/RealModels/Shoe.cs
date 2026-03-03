using System;
using System.Collections.Generic;

namespace Api_Shoes_v1.RealModels;

public partial class Shoe
{
    public int Id { get; set; }

    public string Model { get; set; } = null!;

    public decimal Size { get; set; }

    public decimal Price { get; set; }

    public int Categoryid { get; set; }

    public virtual Category Category { get; set; } = null!;
}
