using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Model
{
    public class Orderline
    {
        public Book Book { get; }
        public int Quantity { get; set; }
        public decimal Subtotal => Book.Price * Quantity;

        public Orderline(Book book, int quantity)
        {
            Book = book;
            Quantity = quantity;
        }


    }
}
