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

        public BookStore EmptyStore { get; }
        public BookStore StoreWithThreeBooks { get; }
        public Book Book1 { get; }
        public Book Book2 { get; }
        public Book Book3 { get; }

        public BookStoreFixture()
        {
            EmptyStore = new();

            Book1 = new("978-1-4842-7868-0", "Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming", "Andrew Troelsen", 299.00M, 10);
            Book2 = new("978-1-59327-826-7", "Serious Cryptography", "Jean-Philippe Aumasson", 349.00M, 8);
            Book3 = new("978-1-4842-3639-0", "Design Patterns in C#", "Vaskaran Sarcar", 199.00M, 12);

            StoreWithThreeBooks = new();
            StoreWithThreeBooks.Add(Book1);
            StoreWithThreeBooks.Add(Book2);
            StoreWithThreeBooks.Add(Book3);
        }
    }
}
