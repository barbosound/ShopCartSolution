using ShopCart.Domain.Enities;
using ShopCart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Infrastructure.Repositories
{
    public class InMemoryShoppingCartRepository : IShoppingCartRepository
    {
        private readonly Dictionary<string, ShoppingCart> _cart = new();

        public ShoppingCart? GetByUserId(string userId)
        {
            _cart.TryGetValue(userId, out var cart);
            return cart;
        }

        public void Save(ShoppingCart cart)
        {
            _cart[cart.UserId] = cart;
        }
    }
}
