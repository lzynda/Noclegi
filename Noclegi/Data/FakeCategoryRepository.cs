using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Noclegi.Models;

namespace Noclegi.Data
{
    public class FakeCategoryRepository : ICategoryRepository
    {
        private List<Category> categories = new List<Category>();


        public IEnumerable<Category> GetCategory()
        {
            return categories;
        }

        public IEnumerable<Category> GetCategory(string name)
        {
            return  categories.Where(c => c.Name.Contains(name));
        }

        public Category GetCategory(int id)
        {
            return  categories.FirstOrDefault(c => c.CategoryId == id);
        }


        public bool CategoryExists(int id)
        {
            return categories.Any(c => c.CategoryId == id);
        }

        public bool CategoryExists(Category c)
        {
            return categories.Any(e => e.Name == c.Name );
        }

        public void AddCategory(Category category)
        {
            categories.Add(category);
        }

        public void DeleteCategory(int categoryId)
        {
            Category category = categories.FirstOrDefault(c => c.CategoryId == categoryId);
            categories.Remove(category);
        }

        public void UpdateCategory(Category category)
        {
            var c = categories.FirstOrDefault(x => x.CategoryId == category.CategoryId);
            c = category;
        }

        public bool Save()
        {
            return  true;
        }
    }
}
