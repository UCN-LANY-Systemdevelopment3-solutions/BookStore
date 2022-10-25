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
    public class Story5Tests : IClassFixture<BookStoreFixture>
    {
        private readonly BookStoreFixture _bookStoreFixture;

        public Story5Tests(BookStoreFixture bookStoreFixture)
        {
            _bookStoreFixture = bookStoreFixture;
        }

        [Fact]
        public void TestAddBookAndVerifySubtotalAndTotal()
        {
            // Arrange
            ShoppingCart cart = new();
            Book book1 = _bookStoreFixture.Book1;
            decimal expectedSubTotal = 598.00M;
            decimal expectedTotal = 598.00M;

            // Act
            cart.Add(book1, 2);            

            // Assert
            Assert.Equal(expectedSubTotal, cart.Orderlines.First().Subtotal);
            Assert.Equal(expectedTotal, cart.Total);
        }

        [Fact]
        public void TestIncreasingBookInCart()
        {
            // Arrange
            ShoppingCart cart = new();
            cart.Add(_bookStoreFixture.Book1);
            Book book2 = _bookStoreFixture.Book2;
            decimal expectedSubTotal = 299.00M;
            decimal expectedTotal = 648.00M;

            // Act
            cart.Add(book2);

            // Assert
            Assert.Equal(expectedSubTotal, cart.Orderlines.First().Subtotal);
            Assert.Equal(expectedTotal, cart.Total);
        }

        [Fact]
        public void TestDecreaseBookInCart()
        {
            // Arrange
            ShoppingCart cart = new();
            cart.Add(_bookStoreFixture.Book1, 2);
            Book book1 = _bookStoreFixture.Book1;
            decimal expectedSubTotal = 299.00M;
            decimal expectedTotal = 299.00M;

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
            ShoppingCart cart = new();
            cart.Add(_bookStoreFixture.Book1, 2);
            Book book1 = _bookStoreFixture.Book1;
            decimal expectedTotal = 0.00M;

            // Act
            cart.Remove(book1, removeAll: true);

            // Assert
            Assert.Empty(cart.Orderlines);
            Assert.Equal(expectedTotal, cart.Total);
        }
    }
}
