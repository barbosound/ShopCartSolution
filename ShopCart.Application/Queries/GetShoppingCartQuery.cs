using MediatR;
using ShopCart.Domain.Enities;

namespace ShopCart.Application.Queries
{
    public record GetShoppingCartQuery(string userId) : IRequest<ShoppingCartResponse>;
}
