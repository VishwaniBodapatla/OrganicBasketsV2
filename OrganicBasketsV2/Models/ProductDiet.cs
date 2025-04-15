using System;
using System.Collections.Generic;

namespace OrganicBasketsV2.Models;

public partial class ProductDiet
{
    public string ProductName { get; set; } = null!;

    public string PartOfDiet { get; set; } = null!;

    public int ProductDietId { get; set; }
}
