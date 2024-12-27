using ShopCart.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Domain.Interfaces
{
    public interface IShoppingCartRepository
    {
        ShoppingCart? GetByUserId(string userId);
        void Save(ShoppingCart cart);
    }
}
