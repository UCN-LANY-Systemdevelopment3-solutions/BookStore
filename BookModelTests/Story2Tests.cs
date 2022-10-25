using BookModelTests.Fixtures;
using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookModelTests
{
    public class Story2Tests : IClassFixture<BookStoreFixture>
    {
        private readonly BookStoreFixture _bookStoreFixture;

        public Story2Tests(BookStoreFixture bookStoreFixture)
        {
            _bookStoreFixture = bookStoreFixture;
        }

        [Fact]
        public void TestSoftDeleteBook()
        {
            // Arrange
            BookStore store = _bookStoreFixture.StoreWithThreeBooks;
            Book book = _bookStoreFixture.Book1;
            string isbn = book.ISBN;

            // Act
            store.Delete(isbn: isbn);

            // Assert
            Assert.Contains(book, store.Titles);
            Assert.True(book.IsDeleted);
        }

        [Fact]
        public void TestDeleteNonExistingBook()
        {
            // Arrange
            BookStore store = _bookStoreFixture.EmptyStore;
            string isbn = "this is a non-existing isbn";

            // Act
            var exception = Record.Exception(()=> store.Delete(isbn));

            // Assert
            Assert.Null(exception);            
        }

        [Fact]
        public void TestDeleteAlreadyDeletedBook()
        {
            // Arrange
            BookStore store = _bookStoreFixture.StoreWithThreeBooks;
            Book book = _bookStoreFixture.Book1;
            string isbn = book.ISBN;

            // Act
            store.Delete(isbn);
            store.Delete(isbn);

            // Assert
            Assert.True(book.IsDeleted);
        }
    }
}
