using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Model
{
    public class ShoppingCart
    {
        private IList<Orderline> _orderlines = new List<Orderline>();

        public IEnumerable<Orderline> Orderlines => _orderlines;

        public decimal Total => _orderlines.Sum(ol => ol.Subtotal);

        public void Add(Book book, int quantity = 1)
        {
            _orderlines.Add(new Orderline(book, quantity));
        }

        public void Remove(Book book, bool removeAll = false)
        {
            Orderline orderline = _orderlines.Single(ol => ol.Book.Equals(book));
            if (removeAll || orderline.Quantity == 1)
            {
                _orderlines.Remove(orderline);
            }
            else
            {
                orderline.Quantity--;
            }
        }
    }
}
