using Microsoft.Extensions.Logging;

namespace ShopCart.Infrastructure.Logging
{
    public class ShoppingCartLogger
    {
        private readonly ILogger<ShoppingCartLogger> _logger;

        public ShoppingCartLogger(ILogger<ShoppingCartLogger> logger)
        {
            _logger = logger;
        }

        public void LogBasketCreated(string userId, string creationDate)
        {
            _logger.LogInformation("[BASKET CREATED]: Created[\"{CreationDate}\"], UserID: {UserId}", creationDate, userId);
        }

        public void LogItemAdded(string userId, string productId, int quantity, decimal price)
        {
            _logger.LogInformation(
                "[ITEM ADDED TO SHOPPING CART]: Added[\"{CreationDate}\"], UserID: {UserId}, ProductID: {ProductId}, Quantity: {Quantity}, Price[\"{Price:C}\"]",
                DateTime.Now.ToString("dd-MM-yyyy"), userId, productId, quantity, price);
        }
    }
}
