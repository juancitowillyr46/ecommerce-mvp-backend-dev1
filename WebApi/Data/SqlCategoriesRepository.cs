using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Data
{
    public class SqlCategoriesRepository : ICategoriesRepository
    {
        private readonly AppDbContext _context;

        public SqlCategoriesRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateCategory(Category category)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCategory(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault<Category>(p => p.Id == id);
        }

        public void UpdateCategory(Category category)
        {
            throw new System.NotImplementedException();
        }
    }
}