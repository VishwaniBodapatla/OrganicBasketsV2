using System;
using System.Collections.Generic;

namespace OrganicBasketsV2.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Country { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public string LocationType { get; set; } = null!;

    public string? UserNameOrVendorName { get; set; }

    public string? UserType { get; set; }
}
