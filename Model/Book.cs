using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Model
{
    public class Book
    {
        public Book(string isbn, string title, string author, decimal price, int stock)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            Price = price;
            Stock = stock;
        }

        public string Author { get; }
        public decimal Price { get; }
        public int Stock { get; }
        public bool IsDeleted { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public IEnumerable<object> Subtotal { get; set; }
    }
}
