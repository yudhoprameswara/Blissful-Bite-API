using System;
using System.Collections.Generic;

namespace BlissfullBite.DataAccess.models;

public partial class Account
{
    public string Username { get; set; } = null!;

    public string? Password { get; set; }
}
