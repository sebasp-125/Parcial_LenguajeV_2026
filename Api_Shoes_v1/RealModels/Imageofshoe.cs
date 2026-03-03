using System;
using System.Collections.Generic;

namespace Api_Shoes_v1.RealModels;

public partial class Imageofshoe
{
    public int Id { get; set; }

    public string? Imagetype { get; set; }

    public bool? Esprincipal { get; set; }

    public string? Url { get; set; }

    public int? Idshoe { get; set; }

    public virtual Shoe? IdshoeNavigation { get; set; }
}
