using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace asp_assignment.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Order> Orders { get; set; }

        [StringLength(15, ErrorMessage = "The {0} must be  at max {1} characters long.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Work Number")]
        public string WorkPhoneNumber { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Home Number")]
        [StringLength(15, ErrorMessage = "The {0} must be  at max {1} characters long.")]
        public string HomePhoneNumber { get; set; }
        public bool Enabled { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "Address")]
        public String Address { get; set; }
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
      
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        [Display(Name = "Full Name")]
        public string FullName { get { return LastName + " " + FirstName; } set { value = LastName + " " + FirstName; } }
    }
}
