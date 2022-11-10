using BookModelTests.Fixtures;
using BookShop.Model;

namespace BookModelTests
{
    public class Story1Tests : IClassFixture<BookStoreFixture>
    {
        private readonly BookStoreFixture _bookStoreFixture;

        // 1. Code the test to validate only the specific requirements.
        // 2. Verify that you can’t compile (because the code you want to test doesn’t exist yet).
        // 3. Implement just enough code (a stub/empty class) to make the code compile.
        // 4. Verify that your test fails
        // 5. Only implement just enough code to make the test pass.

        public Story1Tests(BookStoreFixture bookStoreFixture)
        {
            _bookStoreFixture = bookStoreFixture;
        }

        [Fact]
        public void TestAddValidBooksToStore()
        {
            // Arrange
            BookStore store = new();
            Book book1 = _bookStoreFixture.Book1;
            Book book2 = _bookStoreFixture.Book2;
            Book book3 = _bookStoreFixture.Book3;

            // Act
            store.Add(book1, 4);
            store.Add(book2, 4);
            store.Add(book3, 10);

            // Assert
            Assert.Equal(18, store.InventoryCount);
        }

        [Theory]
        [InlineData("ISBN", "", "Serious Cryptography", "Jean-Philippe Aumasson", 349.00)]
        [InlineData("Title", "978-1-59327-826-7", "", "Jean-Philippe Aumasson", 349.00)]
        [InlineData("Author", "978-1-59327-826-7", "Serious Cryptography", "", 349.00)]
        [InlineData("Price", "978-1-59327-826-7", "Serious Cryptography", "Jean-Philippe Aumasson", -349.00)]
        public void TestAddBookWithInvalidArgumentToStore(string argument, string isbn, string title, string author, decimal price)
        {
            // Arrange
            BookStore store = new();
            Book book2 = new(isbn, title, author, price);

            // Act
            // Assert
            Assert.Throws<ArgumentException>(argument, () => { store.Add(book2, 1); });
        }
    }
}