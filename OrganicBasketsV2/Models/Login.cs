using System;
using System.Collections.Generic;

namespace OrganicBasketsV2.Models;

public partial class Login
{
    public int LoginId { get; set; }

    public string UserName { get; set; } = null!;

    public DateTime LoginTime { get; set; }

    public string UserType { get; set; } = null!;
}
