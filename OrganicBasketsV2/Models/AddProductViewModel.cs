namespace OrganicBasketsV2.Models
{
    public class AddProductViewModel
    {
        public int ProductId { get; set; }

        public string Category { get; set; } = null!;

        public string ProductName { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public int? VendorId { get; set; }

        public string? ProductImage { get; set; }

        public string? Packaging_Unit { get; set; }

        public List<string> PartOfDiet { get; set; } = new List<string>();  // This should be a list of strings

        public List<string> RichInHealthBenefits { get; set; } = new List<string>();

        public string? IsVegan { get; set; }
        public string? IsGlutenFree { get; set; }

    }
}
