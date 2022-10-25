using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Model
{
    public class Book
    {
        public Book(string isbn, string title, string v3, double v4, int v5)
        {
            ISBN = isbn;
            Title = title;
            V3 = v3;
            V4 = v4;
            V5 = v5;
        }

        public string V3 { get; }
        public double V4 { get; }
        public int V5 { get; }
        public bool IsDeleted { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public IEnumerable<object> Subtotal { get; set; }
    }
}
