using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Data
{
    public class MockCategoryRepository : ICategoryRepository
    {
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
            var categoriesItems = new List<Category>{
                new Category{Id=1, Name="Category 1", Description="Description 1", Image="image1.png"},
                new Category{Id=2, Name="Category 2", Description="Description 2", Image="image2.png"},
                new Category{Id=3, Name="Category 3", Description="Description 3", Image="image3.png"}
            };
            return categoriesItems;
        }

        public Category GetCategoryById(int id)
        {
            return new Category{
                Id=1,
                Name="Category 1",
                Description="Description 1",
                Image="image1.png"
            };
        }

        public void UpdateCategory(Category category)
        {
            throw new System.NotImplementedException();
        }
    }
}