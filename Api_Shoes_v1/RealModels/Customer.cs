using System;
using System.Collections.Generic;

namespace Api_Shoes_v1.RealModels;

public partial class Customer
{
    public int Id { get; set; }

    public string Completename { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phonenumber { get; set; }

    public string Password { get; set; } = null!;
}
