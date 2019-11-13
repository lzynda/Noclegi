using Microsoft.VisualStudio.TestTools.UnitTesting;
using Noclegi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Noclegi.Tests.Models
{
    [TestClass]
    public class DistrictTest
    {
        [TestMethod]
        public void DistrictIsValid()
        {
            var district = new District
            {
                Name = "Test"
            };

            var context = new ValidationContext(district, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(district, context, result, true);

            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void DistrictWithLessThanMinimumNameLength()
        {
            var district = new District
            {
                Name = "Te"
            };

            var context = new ValidationContext(district, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(district, context, result, true);

            Assert.IsFalse(valid);
        }

        [TestMethod]
        public void DistricWithMoreThanMaximumNameLength()
        {
            var district = new District
            {
                Name = "TestTestTestTestTestTest"
            };

            var context = new ValidationContext(district, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(district, context, result, true);

            Assert.IsFalse(valid);
        }
    }
}
