using System;
using System.Collections.Generic;

namespace OrganicBasketsV2.Models;

public partial class Vendor
{
    public int VendorId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string ContactPerson { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateTime? CreatedAt { get; set; }
}
