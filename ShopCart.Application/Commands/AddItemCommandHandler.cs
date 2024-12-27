using MediatR;
using ShopCart.Domain.Enities;
using ShopCart.Domain.Interfaces;
using ShopCart.Infrastructure.Logging;

namespace ShopCart.Application.Commands
{
    public class AddItemCommandHandler : IRequestHandler<AddItemCommand, Unit>
    {
        private static readonly Dictionary<string, ShoppingCart> UserCarts = new();
        private static readonly Dictionary<string, Product> AvailableProducts = new()
        {
            { "10001", new Product ("10001", "Lord of the Rings", 10.00m ) },
            { "10002", new Product ("10002", "The Hobbit", 5.00m ) },
            { "20001", new Product ("20001", "Game of Thrones", 9.00m ) },
            { "20110", new Product ("20110", "Breaking Bad", 7.00m ) }
        };

        private readonly ShoppingCartLogger _logger;
        private readonly IShoppingCartRepository _repository;

        public AddItemCommandHandler(ShoppingCartLogger logger, IShoppingCartRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public Task<Unit> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            var cart = _repository.GetByUserId(request.UserId);
            if (cart == null)
            {
                cart = new ShoppingCart
                {
                    UserId = request.UserId,
                    CreationDate = DateTime.Now.ToString("dd/MM/yyyy")

                };
                _logger.LogBasketCreated(request.UserId, cart.CreationDate);
            }

            var product = AvailableProducts[request.ProductId];

            var existingItem = cart.Items.FirstOrDefault(item => item.ProductId == request.ProductId);
            if (existingItem == null)
            {
                cart.Items.Add(new ShoppingCartItem(product.Id, product.Name, product.Price, request.Quantity));
            }
            else
            {
                existingItem.Quantity += request.Quantity;
            }

            _repository.Save(cart);

            _logger.LogItemAdded(request.UserId, request.ProductId, request.Quantity, product.Price);

            return Task.FromResult(Unit.Value);
        }
    }
}
