using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookModelTests.Fixtures
{
    public class ShoppingCartFixture
    {
        public ShoppingCart EmptyCart { get; }
        public ShoppingCart CartWithThreeBooks { get; }

        public Book Book { get; }

        public ShoppingCartFixture()
        {
            EmptyCart = new ShoppingCart();
            Book = new("978-1-4842-3639-0", "Design Patterns in C#", "Vaskaran Sarcar", 199.00, 12);
          
            CartWithThreeBooks = new ShoppingCart();
            CartWithThreeBooks.Add(Book, 3);
        }

    }
}
