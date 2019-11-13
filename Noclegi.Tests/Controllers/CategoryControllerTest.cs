using System;
using System.Collections.Generic;
using System.Text;
using Noclegi.Controllers;
using Noclegi.Data;
using Noclegi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Noclegi.Tests.Controllers
{
    [TestClass]
    public class CategoryControllerTest
    {
        

        [TestMethod]
        public void CreateCategoryWithArgument()
        {
            var categoryRepository = new FakeCategoryRepository();

            var controller = new CategoriesController(categoryRepository);

            var category = new Category();

            var result =  controller.Create(category);

            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }
        
        [TestMethod]
        public void EditCategoryNotInDatabase()
        {
            var categoryRepository = new FakeCategoryRepository();

            var controller = new CategoriesController(categoryRepository);       

            var result = controller.Edit(1);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));

        }


        
        [TestMethod]
        public void EditCategoryWithArgumentAndIncorrectId()
        {
            var categoryRepository = new FakeCategoryRepository();

            var controller = new CategoriesController(categoryRepository);

            var category = new Category()
            {
                CategoryId = 1,
                Name = "Test"
            };

            var result = controller.Edit(2, category);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));

        }

                

      
        [TestMethod]
        public void DeleteCategoryNotInDatabase()
        {
            var categoryRepository = new FakeCategoryRepository();

            var controller = new CategoriesController(categoryRepository);

            var result = controller.Delete(1);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));

        }

     
       
        [TestMethod]
        public void DeleteCategoryWithArgumentAndIncorrectId()
        {
            var categoryRepository = new FakeCategoryRepository();

            var controller = new CategoriesController(categoryRepository);

            var category = new Category()
            {
                CategoryId = 1,
                Name = "Test"
            };

            var result = controller.Delete(2);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));

        }

        [TestMethod]
        public void EditCategoryWithArgumentAndCorrectId()
        {
            var category = new Category()
            {
                CategoryId = 1,
                Name = "Test"
            };

            var categoryEditData = new Category()
            {
                CategoryId = 1,
                Name = "EditTest",
            };

            var m = new Mock<ICategoryRepository>();

            m.Setup(x => x.GetCategory(1)).Returns(category);

            var controller = new CategoriesController(m.Object);



            var result = controller.Edit(1, categoryEditData);

            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));

        }

        [TestMethod]
        public void DeleteCategoryWithArgumentAndcorrectId()
        {
            var category = new Category()
            {
                CategoryId = 1,
                Name = "Test"
            };

            var service = new Mock<ICategoryRepository>();

            service.Setup(x => x.GetCategory(1)).Returns(category);

            var controller = new CategoriesController(service.Object);

            

            var result = controller.DeleteConfirmed(1);

            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));

        }


        [TestMethod] 
        public void NumbersOfCategoriesWithEmptyData()
        {
            
            var categories = new List<Category>()
            {
                new Category(),
                new Category(),
                new Category(),
                new Category(),
                new Category()
            };

            var m = new Mock<ICategoryRepository>();
            m.Setup(x => x.GetCategory()).Returns(categories);
            var controller = new CategoriesController(m.Object);
                        
            var result =  controller.Index();
            
            var viewResult = (ViewResult)result;
            var model = ((ViewResult)result).Model as List<Category>;
            Assert.AreEqual(5, model.Count);
        }



        [TestMethod]
        public void  DetailsOfCategoryExists()
        {
            var cat1 = new Category() {CategoryId = 1, Name = "cat1" };
            var cat2 = new Category() {CategoryId = 2, Name = "cat2" };

            var m = new Mock<ICategoryRepository>();

            m.Setup(x => x.GetCategory(1)).Returns(cat1);
            m.Setup(x => x.GetCategory(2)).Returns(cat2);
            var controller = new CategoriesController(m.Object);

            var result = controller.Details(2);

            var model = ((ViewResult)result).Model as Category;
            Assert.AreEqual(cat2, model);
        }
    }
}
