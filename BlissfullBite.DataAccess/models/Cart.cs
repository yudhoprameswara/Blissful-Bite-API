using System;
using System.Collections.Generic;

namespace BlissfullBite.DataAccess.models;

public partial class Cart
{
    public int Id { get; set; }

    public int FoodId { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public virtual Food Food { get; set; } = null!;
}
