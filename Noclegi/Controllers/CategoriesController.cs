using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Noclegi.Data;
using Noclegi.Helpers;
using Noclegi.Models;



namespace Noclegi.Controllers
{
    [Authorize(Roles = RoleHelper.Administrator)]
    public class CategoriesController : Controller
    {        

        private readonly ICategoryRepository _categoryRepository;


        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            
        }

        public IActionResult Index()
        {
            return View(_categoryRepository.GetCategory());
        }

        
        public IActionResult Details(int id)
        {
            var category =  _categoryRepository.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CategoryId,Name")] Category category)
        {
            Console.WriteLine("test");
              if (ModelState.IsValid)
              {
                    
                   _categoryRepository.AddCategory(category);
                   _categoryRepository.Save();

                   return RedirectToAction(nameof(Index));
              }

              return View(category);
        }

        
        public IActionResult Edit(int id)
        {
              var player = _categoryRepository.GetCategory(id);
              if (player == null)
              {
                     return NotFound();
              }
              

              return View(player);
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CategoryId,Name")] Category category)
        {
              if (id != category.CategoryId)
              {
                    return NotFound();
              }

              if (ModelState.IsValid)
              {
                  try
                  {
                      _categoryRepository.UpdateCategory(category);
                      _categoryRepository.Save();
                   }
                  catch (DbUpdateConcurrencyException)
                  {
                      if (!CategoryExists(category.CategoryId))
                      {
                          return NotFound();
                      }
                      else
                      {
                          throw;
                      }
                  }
                  return RedirectToAction(nameof(Index));
              }
              return View(category);
        }

        
        public IActionResult Delete(int id)
        {
             if (id == null)
             {
                   return NotFound();
             }

             var category = _categoryRepository.GetCategory(id);
             if (category == null)
             {
                  return NotFound();
             }

             return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
             var category = _categoryRepository.GetCategory(id);
             _categoryRepository.DeleteCategory(id);
             _categoryRepository.Save();

            return RedirectToAction(nameof(Index));
        }
                

         public bool CategoryExists(int id)
        {
            return _categoryRepository.CategoryExists(id);
        }

        public bool PlayerExists(Category c)
        {
            return _categoryRepository.CategoryExists(c);
        }

    }
}
