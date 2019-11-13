using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Noclegi.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        public ICollection<RentOffer> RentOffer { get; set; }
    }
}
