using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace asp_assignment.Models
{
    public enum OrderStatus
    {
        Waiting, Shipped
    }
    public class Order
    {
        [Display(Name = "Order Number")]
        public int OrderID { get; set; }
        [Required]
        [Display(Name = "Order Status")]
        public OrderStatus OrderStatus { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        [StringLength(30, ErrorMessage = "The {0} must be  at max {1} characters long.")]
        public string MobilePhoneNumber { get; set; }
      
        public decimal SubTotal { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
      
        public string UserID { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<OrderSouvenir> OrderSouvenirs { get; set; }
       

        public decimal GST
        {

            get
            {
                return SubTotal * 15 / 100;
            }
            set
            {
                value = SubTotal * 15 / 100;
            }
        }
        [Display(Name = "Grand Total")]
        public decimal Total
        {
            get
            {
                return SubTotal + GST;
            }
            set
            {
                value = SubTotal + GST;
            }
        }
    }
}
