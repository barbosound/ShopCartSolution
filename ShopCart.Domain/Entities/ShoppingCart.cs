namespace ShopCart.Domain.Enities
{
    public class ShoppingCart
    {
        public string UserId { get; set; } = string.Empty;

        public string CreationDate { get; set; } = string.Empty;

        public IList<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public decimal Total => Items.Sum(i => i.TotalPrice);
    }
}
