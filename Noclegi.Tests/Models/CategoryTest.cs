using Microsoft.VisualStudio.TestTools.UnitTesting;
using Noclegi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Noclegi.Tests.Models
{
    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        public void CategoryIsValid()
        {
            var model = new Category
            {
                Name = "Test"
            };

            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();
         
            var valid = Validator.TryValidateObject(model, context, result, true);
            
            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void CategoryWithLessThanMinimumNameLength()
        {
            var model = new Category
            {
                Name = "Te"
            };

            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);
        }

        [TestMethod]
        public void CategoryWithMoreThanMaximumNameLength()
        {
            var model = new Category
            {
                Name = "TestTestTestTestTestTest"
            };

            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);
        }
    }
}
