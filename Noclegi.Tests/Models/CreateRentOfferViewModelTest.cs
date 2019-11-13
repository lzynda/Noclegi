using Microsoft.VisualStudio.TestTools.UnitTesting;
using Noclegi.Models;
using Noclegi.Models.RentOfferViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Noclegi.Tests.Models
{
    [TestClass]
    public class CreateRentOfferViewModelTest
    {
        [TestMethod]
        public void CreateRentIsValid()
        {
            
            var rent = new CreateRentOfferViewModel
            {
            
                PostalCode = "82-300",

                Title = "Testtesttest",

                Description = "Testtesttest",
                
                Price = 20

            };

            var context = new ValidationContext(rent, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(rent, context, result, true);

            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void CreateRentWithLessThanMinimumTitleLength()
        {

            var rent = new CreateRentOfferViewModel
            {

                PostalCode = "82-300",

                Title = "Tes",

                Description = "Testtesttest",

                Price = 20

            };

            var context = new ValidationContext(rent, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(rent, context, result, true);

            Assert.IsFalse(valid);
        }


        [TestMethod]
        public void CreateRentWithoutRequiredPostalcode()
        {

            var rent = new CreateRentOfferViewModel
            {               

                Title = "Testtesttest",

                Description = "Testtesttest",

                Price = 20

            };

            var context = new ValidationContext(rent, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(rent, context, result, true);

            Assert.IsFalse(valid);
        }

        [TestMethod]
        public void CreateRentWithoutRequiredTitle()
        {

            var rent = new CreateRentOfferViewModel
            {

                PostalCode = "82-300",

                Description = "Testtesttest",

                Price = 20

            };

            var context = new ValidationContext(rent, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(rent, context, result, true);

            Assert.IsFalse(valid);
        }

        [TestMethod]
        public void CreateRentWithNegativePrice()
        {

            var rent = new CreateRentOfferViewModel
            {
                Title = "Testtesttest",

                PostalCode = "82-300",

                Description = "Testtesttest",

                Price = -2

            };

            var context = new ValidationContext(rent, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(rent, context, result, true);

            Assert.IsFalse(valid);
        }
    }
}
