using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_assignment.Models
{
    public class OrderSouvenir
    {

        public int OrderSouvenirID { get; set; }

        public int SouvenirID { get; set; }

        public int OrderID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public Souvenir Souvenir { get; set; }
        public Order Order { get; set; }
    }
}
