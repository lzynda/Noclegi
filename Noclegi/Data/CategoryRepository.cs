using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Noclegi.Models;
using Microsoft.EntityFrameworkCore;

namespace Noclegi.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetCategory()
        {
            return _context.Category.ToList(); 
        }

        public IEnumerable<Category> GetCategory(String name)
        {
            return  _context.Category.Where(n => n.Name.Contains(name)).ToList();
        }

        public Category GetCategory(int id)
        {
            return  _context.Category.SingleOrDefault(x => x.CategoryId == id);
        }

        public bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }

        public bool CategoryExists(Category c)
        {
            return _context.Category.Any(e => e.Name == c.Name);
        }

        public void AddCategory(Category category)
        {
            _context.Category.Add(category);
        }

        public void DeleteCategory(int categoryId)
        {
            Category category = _context.Category.Find(categoryId);
            _context.Category.Remove(category);
        }

        public void UpdateCategory(Category category)
        {
            _context.Update(category);
        }

        public bool Save()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception) { return false; };
        }
    }
}
