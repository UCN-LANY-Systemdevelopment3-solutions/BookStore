using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Model
{
    public class ShoppingCart
    {
        public IEnumerable<Book> Orderlines { get; set; }
        public decimal Total { get; set; }

        public void Add(Book book1)
        {
            throw new NotImplementedException();
        }
    }
}
