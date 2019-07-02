using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public double TotalAmount { get; set; }

        public IEnumerable<OrderLine> OrderLines { get; set; }
    }
}
