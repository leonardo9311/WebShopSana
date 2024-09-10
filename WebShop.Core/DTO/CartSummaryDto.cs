using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.DTO
{
    public class CartSummaryDto
    {
        public decimal TotalPrice { get; set; }
        public int TotalItems { get; set; }
    }
}
