using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Model
{
    public class ShoppingCart
    {
        public IEnumerable<Orderline> Orderlines { get; set; }
        public decimal Total { get; set; }

        public void Add(Book book1, int quantity = 1)
        {
            throw new NotImplementedException();
        }

        public void Remove(Book book1, bool removeAll = false)
        {
            throw new NotImplementedException();
        }
    }
}
