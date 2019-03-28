using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace asp_assignment.Models
{
    public class Souvenir
    {
        public int SouvenirID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Souvenir Name")]
        public string Name { get; set; }
       
        [Display(Name = "Image")]
        public string PathOfFile { get; set; }
    
        [StringLength(100, ErrorMessage = "The {0} must be at max {1} characters long.")]   
        public string Description { get; set; }
        [Required]
        [Range(0,999999, ErrorMessage = "Price should be more than $0 and less than $999999")]
        public decimal Price { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public Category Category { get; set; }

        public Supplier Supplier { get; set; }
        public ICollection<CartItem> CartItems{ get; set; }
        public ICollection<OrderSouvenir> OrderSouvenirs { get; set; }
    }
}
