using System;
using System.Collections.Generic;

namespace OrganicBasketsV2.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? UserName { get; set; }

    public string? UserType { get; set; }

    public string? IsVendor { get; set; }
}
