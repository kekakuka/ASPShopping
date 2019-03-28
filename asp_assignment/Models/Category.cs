using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace asp_assignment.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
       
        [StringLength(100, ErrorMessage = "The {0} must be  at max {1} characters long.")]
       
        public string Description { get; set; }

        public ICollection<Souvenir> Souvenirs { get; set; }
    }
}
