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
        public BookStoreFixture()
        {
            Store = new();
            Book1 = new("978-1-4842-7868-0", "Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming", "Andrew Troelsen", 299.00, 10);
            Book2 = new("978-1-59327-826-7", "Serious Cryptography", "Jean-Philippe Aumasson", 349.00, 8);
            Book3 = new("978-1-4842-3639-0", "Design Patterns in C#", "Vaskaran Sarcar", 199.00, 12);
        }

        public BookStore Store { get; }
        public Book Book1 { get; }
        public Book Book2 { get; }
        public Book Book3 { get; }

        internal BookStore CreateEmptyStore()
        {
            throw new NotImplementedException();
        }
    }
}
