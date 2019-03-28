using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace asp_assignment.Models
{
    public class Supplier
    {
        public int SupplierID{ get; set; }
        [StringLength(100, ErrorMessage = "The {0} must be  at max {1} characters long.")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Email Address")]
       [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [StringLength(15, ErrorMessage = "The {0} must be  at max {1} characters long.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Work Number")]
        public string WorkPhoneNumber { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Home Number")]
        [StringLength(15, ErrorMessage = "The {0} must be  at max {1} characters long.")]
        public string HomePhoneNumber { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, ErrorMessage = "The {0} must be  at max {1} characters long.")]
        [Display(Name = "Mobile Number")]
        public string MobilePhoneNumber { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Full Number")]
        public string FullName { set { value= LastName + " " + FirstName; } get { return LastName +" "+ FirstName; } }

        public ICollection<Souvenir> Souvenirs { get; set; }
    }
}
