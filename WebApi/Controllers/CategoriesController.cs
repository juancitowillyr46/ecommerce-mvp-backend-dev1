using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController: ControllerBase
    {
        private readonly ICategoriesRepository _repository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoriesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet()]
        public ActionResult <IEnumerable<CategoryReadDto>> GetAllCategories()
        {
            var categoriesItems = _repository.GetAllCategories();
            return Ok(_mapper.Map<List<CategoryReadDto>>(categoriesItems));
        }

        // [HttpGet("{id}")]
        // public ActionResult <CategoryReadDto> GetCategoryById(int id)
        // {
        //     var categoryItem = _repository.GetCategoryById(id);
        //     return Ok(_mapper.Map<CategoryReadDto>(categoryItem));
        // }
    }
}