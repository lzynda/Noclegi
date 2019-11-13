using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Noclegi.Models;

namespace Noclegi.Data
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategory();
        IEnumerable<Category> GetCategory(string name);
        Category GetCategory(int categoryId);
        bool CategoryExists(int categoryId);
        bool CategoryExists(Category category);
        void AddCategory(Category category);
        void DeleteCategory(int categoryId);
        void UpdateCategory(Category category);
        bool Save();

    }
}
