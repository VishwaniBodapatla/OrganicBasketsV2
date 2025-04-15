namespace OrganicBasketsV2.Models
{
    public class CartItemViewModel
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductImage { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice => Price * Quantity;

        public string PackagingUnit { get; set; }
        public string? Description { get; set; }
        public string Category { get; set; } = null!;



        public int Stock { get; set; }


    }
}
