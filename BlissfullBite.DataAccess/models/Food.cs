using System;
using System.Collections.Generic;

namespace BlissfullBite.DataAccess.models;

public partial class Food
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Category { get; set; } = null!;

    public decimal Price { get; set; }

    public bool? Availability { get; set; }

    public string? Description { get; set; }

    public string? ImagePath { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
}
