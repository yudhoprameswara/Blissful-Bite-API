using System;
using System.Collections.Generic;

namespace BlissfullBite.DataAccess.models;

public partial class Outlet
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Contact { get; set; } = null!;

    public string? LinkAddress { get; set; }
}
