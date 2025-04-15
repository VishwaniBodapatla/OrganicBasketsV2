using System;
using System.Collections.Generic;

namespace OrganicBasketsV2.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public string? OrderStatus { get; set; }

    public string? UserName { get; set; }

    public DateTime? OrderededAt { get; set; }

    public int CartId { get; set; }
}
