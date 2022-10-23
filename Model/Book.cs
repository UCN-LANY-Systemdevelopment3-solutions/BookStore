using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Model
{
    public class Book
    {
        public Book(string v1, string v2, string v3, double v4, int v5)
        {
            V1 = v1;
            V2 = v2;
            V3 = v3;
            V4 = v4;
            V5 = v5;
        }

        public string V1 { get; }
        public string V2 { get; }
        public string V3 { get; }
        public double V4 { get; }
        public int V5 { get; }
        public bool IsDeleted { get; set; }
        public string ISBN { get; set; }
    }
}
