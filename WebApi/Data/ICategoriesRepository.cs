using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Data
{
    public interface ICategoriesRepository
    {
        IEnumerable<Category> GetAllCategories();
        void CreateCategory(Category category);
        Category GetCategoryById(int id);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}