using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace asp_assignment.Models.ManageViewModels
{
    public class IndexViewModel
    {
        [Required]

        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 character.")]

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 character.")]

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get { return LastName + " " + FirstName; } set { value = LastName + " " + FirstName; } }

        public IEnumerable<Order> Orders { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

     

        public string StatusMessage { get; set; }
      

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, ErrorMessage = "The {0} must be  at max {1} characters long.")]
        [Display(Name = "Mobile Number")]
        public string MobilePhoneNumber { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string HomePhoneNumber { get; set; }
    }
}
