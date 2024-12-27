using ShopCart.Domain.Enities;
using ShopCart.Infrastructure.Repositories;

namespace ShopCart.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void AddItemToNewCart_ShouldCreateCart()
        {
            // Arrange
            var repository = new InMemoryShoppingCartRepository();
            var cart = new ShoppingCart { UserId = "01", CreationDate = "27-12-2024" };

            // Act
            repository.Save(cart);
            var retrievedCart = repository.GetByUserId("01");

            // Assert
            Assert.NotNull(retrievedCart);
            Assert.Equal("01", retrievedCart.UserId);
        }

        [Fact]
        public void AddItemToExistingCart_ShouldUpdateQuantity()
        {
            // Arrange
            var repository = new InMemoryShoppingCartRepository();
            var cart = new ShoppingCart { UserId = "01", CreationDate = "27-12-2024" };
            cart.Items.Add(new ShoppingCartItem ("10002", "Hobbit", 10.00m, 1));
            repository.Save(cart);

            // Act
            var retrievedCart = repository.GetByUserId("01");
            var item = retrievedCart.Items.FirstOrDefault(i => i.ProductId == "10002");
            if (item != null)
            {
                item.Quantity += 1;
            }
            repository.Save(retrievedCart);

            // Assert
            retrievedCart = repository.GetByUserId("01");
            Assert.NotNull(retrievedCart);
            Assert.Single(retrievedCart.Items);
            Assert.Equal(2, retrievedCart.Items.First().Quantity);
        }
    }
}