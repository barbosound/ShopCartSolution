using MediatR;

namespace ShopCart.Application.Commands
{
    public class AddItemCommand : IRequest<Unit>
    {
        public string UserId { get; set; } = string.Empty;

        public string ProductId { get; set; } = string.Empty;

        public int Quantity { get; set; }
    }
}
