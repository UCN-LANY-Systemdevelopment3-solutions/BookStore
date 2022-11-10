using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookModelTests.Fixtures
{
    public class BookStoreFixture
    {
        public Book Book1 { get; }
        public Book Book2 { get; }
        public Book Book3 { get; }

        public BookStore StoreWithThreeBooks
        {
            get
            {
                BookStore bookStore = new();
                bookStore.Add(Book1, 4);
                bookStore.Add(Book2, 4);
                bookStore.Add(Book3, 10);

                return bookStore;
            }
        }

        public BookStoreFixture()
        {
            Book1 = new("978-1-4842-7868-0", "Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming", "Andrew Troelsen", 299.00M);
            Book2 = new("978-1-59327-826-7", "Serious Cryptography", "Jean-Philippe Aumasson", 349.00M);
            Book3 = new("978-1-4842-3639-0", "Design Patterns in C#", "Vaskaran Sarcar", 199.00M);
        }
    }
}
