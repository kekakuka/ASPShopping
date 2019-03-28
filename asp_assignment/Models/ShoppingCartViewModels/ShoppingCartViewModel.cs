using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_assignment.Models.ShoppingCartViewModels
{
    public class ShoppingCartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal CartTotal { get; set; }
        public int GetNumberOfItems()
        {
            int numbers = 0;
            for (int i = 0; i < CartItems.Count; i++)
            {
                numbers += CartItems[i].Count;
            }
            return numbers;
        }
        public decimal GST
        {

            get
            {
                return CartTotal * 15 / 100;
            }
            set
            {
                value = CartTotal * 15 / 100;
            }
        }
        public decimal Total
        {
            get
            {
                return CartTotal + GST;
            }
            set
            {
                value = CartTotal + GST;
            }
        }
    }
}
