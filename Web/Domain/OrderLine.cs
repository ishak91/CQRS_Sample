using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Domain
{
    public class OrderLine
    {
        public int Id { get; set; }
        public string ItemNo { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

        public double Amount { get {
                return UnitPrice * Quantity;
            }
        }
    }
}
