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
        public void AddValidBooksToStore()
        {
            // Arrange
            BookStore store = _bookStoreFixture.Store;
            Book book1 = _bookStoreFixture.Book1;
            Book book2 = _bookStoreFixture.Book2;
            Book book3 = _bookStoreFixture.Book3;

            // Act
            store.Add(book1);
            store.Add(book2);
            store.Add(book3);

            // Assert
            Assert.Equal(3, store.Titles.Count());
        }

        [Fact]
        public void AddBookWithInvalidISBNToStore()
        {
            // Arrange
            BookStore store = new();
            Book book2 = new(string.Empty, "Serious Cryptography", "Jean-Philippe Aumasson", 349.00, 8);

            // Act
            // Assert
            Assert.Throws<ArgumentException>("isbn", () => { store.Add(book2); });
        }

        [Fact]
        public void AddBookWithInvalidTitleToStore()
        {
            // Arrange
            BookStore store = new();
            Book book2 = new("978-1-59327-826-7", string.Empty, "Jean-Philippe Aumasson", 349.00, 8);

            // Act
            // Assert
            Assert.Throws<ArgumentException>("title", () => { store.Add(book2); });
        }

        [Fact]
        public void AddBookWithInvalidAuthorToStore()
        {
            // Arrange
            BookStore store = new();
            Book book2 = new("978-1-59327-826-7", "Serious Cryptography", string.Empty, 349.00, 8);

            // Act
            // Assert
            Assert.Throws<ArgumentException>("title", () => { store.Add(book2); });
        }

        [Fact]
        public void AddBookWithNegativePriceToStore()
        {
            // Arrange
            BookStore store = new();
            Book book2 = new("978-1-59327-826-7", "Serious Cryptography", "Jean-Philippe Aumasson", -349.00, 8);

            // Act
            // Assert
            Assert.Throws<ArgumentException>("title", () => { store.Add(book2); });
        }
    }
}