using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Noclegi.Models
{
    public class RentOffer
    {
               
        public string RentOfferId { get; set; }

        public ApplicationUser Author { get; set; }

        [Display(Name = "Postal code")]
        public string PostalCode { get; set; }

        [Display(Name = "Category")]
        public Category Category { get; set; }

        [Display(Name = "District")]
        public District District { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
