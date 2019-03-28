using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_assignment.Models.WebsiteViewModels
{
    public class SouvenirInCategory
    {
      
        public IEnumerable<Category> Categories { get; set; }
        public PaginatedList<Souvenir> Souvenirs { get; set; }
       
    }
}
