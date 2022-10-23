using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Model
{
    public class BookStore
    {
        public IEnumerable<Book> Titles { get; set; }

        public void Add(Book book1)
        {
            throw new NotImplementedException();
        }
    }
}
