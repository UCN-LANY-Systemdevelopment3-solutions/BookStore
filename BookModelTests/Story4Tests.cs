using BookModelTests.Fixtures;
using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookModelTests
{
    public class Story4Tests : IClassFixture<BookStoreFixture>, IClassFixture<ShoppingCartFixture>
    {
        private readonly BookStoreFixture _bookStoreFixture;
        private readonly ShoppingCartFixture _shoppingCartFixture;

        public Story4Tests(BookStoreFixture bookStoreFixture, ShoppingCartFixture shoppingCartFixture)
        {
            _bookStoreFixture = bookStoreFixture;
            _shoppingCartFixture = shoppingCartFixture;
        }

        [Fact]
        public void TestPutBookIntoCart()
        {
            // Arrange
            ShoppingCart cart = _shoppingCartFixture.EmptyCart;
            Book book1 = _bookStoreFixture.Book1;
            decimal expectedTotal = 299.00M;

            // Act
            cart.Add(book1);

            // Assert
            Assert.Single(cart.Orderlines);
            Assert.Contains(book1, cart.Orderlines.Select(ol => ol.Book));
            Assert.Equal(expectedTotal, cart.Total);
        }


        [Fact]
        public void TestCalculateTotalsWhenAddingBookToCart()
        {
            // Arrange
            ShoppingCart cart = _shoppingCartFixture.EmptyCart;
            Book book1 = _bookStoreFixture.Book1;
            Book book2 = _bookStoreFixture.Book2;
            Book book3 = _bookStoreFixture.Book3;
            decimal expectedTotal = 1146.00M;

            // Act
            cart.Add(book1, 2);
            cart.Add(book2);
            cart.Add(book3);

            // Assert
            Assert.Equal(3, cart.Orderlines.Count());
            Assert.Equal(expectedTotal, cart.Total);
        }
    }
}
