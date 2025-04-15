using System;
using System.Collections.Generic;

namespace OrganicBasketsV2.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Category { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public int? VendorId { get; set; }

    public string? ProductImage { get; set; }

    public string? PackagingUnit { get; set; }

    public string? PartOfDiet { get; set; }

    public string? RichInHealthBenefits { get; set; }

    public string? IsVegan { get; set; }

    public string? IsGlutenFree { get; set; }
}
