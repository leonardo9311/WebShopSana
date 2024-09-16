using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Entity
{
    public class OrderDetail
    {
        public int OrderID { get; set; }
        public Order Order { get; set; } = new Order();
        public int ProductID { get; set; }
        public Product Product { get; set; } = new Product();
        public int Quantity { get; set; }

        public decimal PriceAtOrderTime { get; set; }
    }
}
