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

        [Theory]
        [InlineData("Serious", null, 1)]
        [InlineData(null, "Sarcar", 1)]
        [InlineData("Serious", "Sarcar", 2)]
        [InlineData("Tqlmzftt", "Afkansh", 0)]
        public void TestSearchForBookByTitleAndOrAuthor(string? searchString1, string? searchString2, int resultCount)
        {
            // Arrange
            BookStore store = _bookStoreFixture.StoreWithThreeBooks;

            // Act
            IEnumerable<Book> result = store.Search(title: searchString1, authorName: searchString2);

            // Assert
            Assert.Equal(resultCount, result.Count());
        }
    }
}
