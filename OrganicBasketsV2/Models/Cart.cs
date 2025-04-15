using System;
using System.Collections.Generic;

namespace OrganicBasketsV2.Models;

public partial class Cart
{
    public int CartId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime? AddedAt { get; set; }

    public string? UserName { get; set; }
}
