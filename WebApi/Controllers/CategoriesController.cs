using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController: ControllerBase
    {
        private readonly ICategoriesRepository _repository;

        public CategoriesController(ICategoriesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet()]
        public ActionResult <IEnumerable<Category>> GetAllCategories()
        {
            var categoriesItems = _repository.GetAllCategories();
            return Ok(categoriesItems);
        }

        [HttpGet("{id}")]
        public ActionResult <Category> GetCategoryById(int id)
        {
            var categoryItem = _repository.GetCategoryById(id);
            return Ok(categoryItem);
        }
    }
}