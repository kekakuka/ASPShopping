using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace asp_assignment.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
       
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 character.")]

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 character.")]
       
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, ErrorMessage = "The {0} must be  at max {1} characters long.")]
        [Display(Name = "Mobile Number")]
        public string MobilePhoneNumber { get; set; }
        [StringLength(15, ErrorMessage = "The {0} must be  at max {1} characters long.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Work Number")]
        public string WorkPhoneNumber { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Home Number")]
        [StringLength(15, ErrorMessage = "The {0} must be  at max {1} characters long.")]
        public string HomePhoneNumber { get; set; }
       


    }
}
