using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookModelTests
{
    public class BookStoreFixture
    {
        public BookStoreFixture()
        {
            Store = new();
            Book1 = new("978-1-4842-7868-0", "Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming", "Andrew Troelsen", 299.00, 10);
            Book2 = new("978-1-59327-826-7", "Serious Cryptography", "Jean-Philippe Aumasson", 349.00, 8);
            Book3 = new("978-1-4842-3639-0", "Design Patterns in C#", "Vaskaran Sarcar", 199.00, 12);
            Store.Add(Book1);
            Store.Add(Book2);
            Store.Add(Book3);
        }

        public BookStore Store { get; }
        public Book Book1 { get; }
        public Book Book2 { get; }
        public Book Book3 { get; }
    }

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
            BookStore store = _bookStoreFixture.Store;
            Book book = _bookStoreFixture.Book1;
            string isbn = book.ISBN;

            // Act
            store.Delete(isbn);

            // Assert
            Assert.Contains(book, store.Titles);
            Assert.True(store.FindByIsbn(isbn).IsDeleted);
        }

        [Fact]
        public void TestDeleteNonExistingBook()
        {
            // Arrange
            BookStore store = _bookStoreFixture.Store;
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
            BookStore store = _bookStoreFixture.Store;
            Book book = _bookStoreFixture.Book1;
            string isbn = book.ISBN;

            // Act
            store.Delete(isbn);
            store.Delete(isbn);

            // Assert
            Assert.True(store.FindByIsbn(isbn).IsDeleted);
        }
    }
}
