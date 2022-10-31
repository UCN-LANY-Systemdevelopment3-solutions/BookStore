using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Model
{
    public class BookStore
    {
        private IList<Book> _titles = new List<Book>();

        public IEnumerable<Book> Titles => _titles;

        public void Add(Book book)
        {
            if (book.ISBN == string.Empty)
                throw new ArgumentException("Invalid value", nameof(book.ISBN));

            if (book.Title == string.Empty)
                throw new ArgumentException("Invalid value", nameof(book.Title));

            if (book.Author == string.Empty)
                throw new ArgumentException("Invalid value", nameof(book.Author));

            if (book.Price < 0)
                throw new ArgumentException("Invalid value", nameof(book.Price));

            _titles.Add(book);
        }

        public void Delete(string isbn)
        {
            Book? book = _titles.SingleOrDefault(b => b.ISBN == isbn);
            if (book != null)
                book.IsDeleted = true;
        }

        public Book FindByIsbn(string v)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> Search(string? title = null, string? authorName = null)
        {
            List<Book> result = new();

            if (title != null)
                result.AddRange(_titles.Where(b => b.Title.Contains(title) && !b.IsDeleted));

            if (authorName != null)
                result.AddRange(_titles.Where(b => b.Author.Contains(authorName) && !b.IsDeleted));

            return result;  
        }
    }
}
