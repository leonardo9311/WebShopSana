using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Entity
{
    public class ProductCategory
    {
        public int ProductID { get; set; }
        public Product Product { get; set; } = new Product();
        public int CategoryID { get; set; }
        public Category Category { get; set; } = new Category();
    }
}
