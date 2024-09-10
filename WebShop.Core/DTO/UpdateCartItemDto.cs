using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.DTO
{
    public class UpdateCartItemDto
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
