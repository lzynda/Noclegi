using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Noclegi.Models.RentOfferViewModels
{

public class CreateRentOfferViewModel
    {
        public string RentOfferId { get; set; }

        //[Required]
        [Display(Name = "Category")]
        public string CategoryId { get; set; }

        //[Required]
        [Display(Name = "District")]
        public District DistrictId { get; set; }

        [Required]
        [Display(Name = "Postal code", Prompt = "xx-xxx")]
        public string PostalCode { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0.0, 1_000_000.0, ErrorMessage = "Price must be between 0.0 and 1000000.0")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<District> Districts { get; set; }
        
    }
}
