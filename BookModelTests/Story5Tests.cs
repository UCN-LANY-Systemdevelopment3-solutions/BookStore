using BookModelTests.Fixtures;
using BookShop.Model;
using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookModelTests
{
    public class Story5Tests : IClassFixture<ShoppingCartFixture>
    {
        private readonly ShoppingCartFixture _shoppingCartFixture;

        public Story5Tests(ShoppingCartFixture shoppingCartFixture)
        {
            _shoppingCartFixture = shoppingCartFixture;
        }

        [Fact]
        public void TestAddBookAndVerifySubtotalAndTotal()
        {
            // Arrange
            ShoppingCart cart = _shoppingCartFixture.EmptyCart;
            Book book1 = _shoppingCartFixture.Book;
            decimal expectedSubTotal = 598.00M;
            decimal expectedTotal = 598.00M;

            // Act
            cart.Add(book1);
            cart.Add(book1);

            // Assert
            Assert.Equal(expectedSubTotal, cart.Orderlines.First().Subtotal);
            Assert.Equal(expectedTotal, cart.Total);
        }

        [Fact]
        public void TestIncreasingBookInCart()
        {
            // Arrange
            ShoppingCart cart = _shoppingCartFixture.CartWithThreeBooks;
            Book book1 = _shoppingCartFixture.Book;
            decimal expectedSubTotal = 1196.00M;
            decimal expectedTotal = 1196.00M;

            // Act
            cart.Add(book1);

            // Assert
            Assert.Equal(expectedSubTotal, cart.Orderlines.First().Subtotal);
            Assert.Equal(expectedTotal, cart.Total);
        }

        [Fact]
        public void TestDecreaseBookInCart()
        {
            // Arrange
            ShoppingCart cart = _shoppingCartFixture.CartWithThreeBooks;
            Book book1 = _shoppingCartFixture.Book;
            decimal expectedSubTotal = 598.00M;
            decimal expectedTotal = 598.00M;

            // Act
            cart.Remove(book1);

            // Assert
            Assert.Equal(expectedSubTotal, cart.Orderlines.First().Subtotal);
            Assert.Equal(expectedTotal, cart.Total);
        }

        [Fact]
        public void TestRemoveBookFromCart()
        {
            // Arrange
            ShoppingCart cart = _shoppingCartFixture.CartWithThreeBooks;
            Book book1 = _shoppingCartFixture.Book;
            decimal expectedTotal = 0.00M;

            // Act
            cart.Remove(book1, removeAll: true);

            // Assert
            Assert.Empty(cart.Orderlines);
            Assert.Equal(expectedTotal, cart.Total);
        }
    }
}
