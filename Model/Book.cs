using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Model
{
    public class Book
    {
        public Book(string isbn, string title, string author, decimal price)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            Price = price;
        }

        public string Author { get; }
        public decimal Price { get; }
        public bool IsDeleted { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
    }
}
