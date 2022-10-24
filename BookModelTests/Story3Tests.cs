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
            string searchString = "";

            // Act
            IEnumerable<Book> result = store.Search(searchString);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Any());
            Assert.Contains<Book>(result, b => b.Title.Contains(searchString));
        }

        [Fact]
        public void TestSearchForBookByPartlyAuthorName()
        {
            // Arrange
            // Act
            // Assert
        }

        [Fact]
        public void TestSearchForBookByPartlyTitleAndPartlyAuthorName()
        {
            // Arrange
            // Act
            // Assert
        }

        [Fact]
        public void TestSearchForBookByWordsThatAreNotPartOfEitherTitleOrName()
        {
            // Arrange
            // Act
            // Assert
        }
    }
}
