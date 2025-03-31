using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flooring_shop
{
    public class Product
    {
        public string Article { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public int QuantityOrdered{ get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
