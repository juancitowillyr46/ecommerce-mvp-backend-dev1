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
    public class UsersController: ControllerBase
    {
        private readonly IUsersRepository _repository;

        private readonly IMapper _mapper;
        
        public UsersController(IUsersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // [HttpGet()]
        // public ActionResult <IEnumerable<User>> GetAllUsers()
        // {
        //     var userItems = _repository.GetAllUsers();
        //     return Ok(userItems);
        // }

        [HttpGet("{id}")]
        public ActionResult <UserReadDto> GetUserById(int id)
        {
            var userItem = _repository.GetUserById(id);
            return Ok(_mapper.Map<UserReadDto>(userItem));
        }
    }
}