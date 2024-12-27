using System.Numerics;

namespace ShopCart.Domain.Enities
{
    public class ShoppingCartResponse
    {
        public string CreationDate { get; set; } = string.Empty;
        public List<string> Items { get; set; } = new List<string>();
        public decimal Total { get; set; }

        public ShoppingCartResponse(ShoppingCart cart)
        {
            CreationDate = cart.CreationDate;

            foreach (var item in cart.Items)
            {
                var itemstr = $"- {item.Quantity} x {item.ProductName} // {item.Quantity} x {item.UnitPrice} = €{item.TotalPrice}";
                Items.Add(itemstr);
            }

            Total = cart.Total;
        }
    }
}
