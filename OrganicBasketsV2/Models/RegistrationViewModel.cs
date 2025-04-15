using System.ComponentModel.DataAnnotations;

namespace OrganicBasketsV2.Models
{
    public class RegistrationViewModel
    {
        // User Fields
        [Required]
        public string FullName { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string UserName { get; set; } = null!;

        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string? UserType { get; set; }

        public string? IsVendor { get; set; }

        // Address Fields
        [Required]
        public string AddressLine1 { get; set; } = null!;

        public string? AddressLine2 { get; set; }

        [Required]
        public string City { get; set; } = null!;

        [Required]
        public string State { get; set; } = null!;

        [Required]
        public string PostalCode { get; set; } = null!;

        [Required]
        public string Country { get; set; } = null!;

        public string? LocationType { get; set; }
    }
}
