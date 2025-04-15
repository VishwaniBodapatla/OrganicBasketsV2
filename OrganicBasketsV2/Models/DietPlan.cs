using System;
using System.Collections.Generic;

namespace OrganicBasketsV2.Models;

public partial class DietPlan
{
    public int DietId { get; set; }

    public string DietName { get; set; } = null!;

    public string? Description { get; set; }

    public string? RecommendedProducts { get; set; }
}
