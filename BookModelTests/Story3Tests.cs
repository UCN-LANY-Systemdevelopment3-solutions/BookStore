using BookModelTests.Fixtures;
using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookModelTests
{
    public class Story3Tests : IClassFixture<BookStoreFixture>
    {
        private readonly BookStoreFixture _bookStoreFixture;

        public Story3Tests(BookStoreFixture bookStoreFixture)
        {
            _bookStoreFixture = bookStoreFixture;
        }

        [Fact]
        public void TestSearchForBookByPartlyTitle()
        {
            // Arrange
            BookStore store = _bookStoreFixture.Store;
            string searchString = "Serious";

            // Act
            IEnumerable<Book> result = store.Search(title: searchString);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Any());
            Assert.Contains<Book>(result, b => b.Title.Contains(searchString));
        }

        [Fact]
        public void TestSearchForBookByPartlyAuthorName()
        {
            // Arrange
            BookStore store = _bookStoreFixture.Store;
            string searchString = "Sarcar";

            // Act
            IEnumerable<Book> result = store.Search(authorName: searchString);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Any());
            Assert.Contains<Book>(result, b => b.Title.Contains(searchString));

        }

        [Fact]
        public void TestSearchForBookByPartlyTitleAndPartlyAuthorName()
        {
            // Arrange
            BookStore store = _bookStoreFixture.Store;
            string searchString1 = "Design";
            string searchString2 = "Sarcar";

            // Act
            IEnumerable<Book> result = store.Search(title: searchString1, authorName: searchString2);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Any());
            Assert.Contains<Book>(result, b => b.Title.Contains(searchString1));
        }

        [Fact]
        public void TestSearchForBookByWordsThatAreNotPartOfEitherTitleOrName()
        {
            // Arrange
            BookStore store = _bookStoreFixture.Store;
            string searchString1 = "Tqlmzftt";
            string searchString2 = "Afkansh";

            // Act
            IEnumerable<Book> result = store.Search(title: searchString1, authorName: searchString2);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}
