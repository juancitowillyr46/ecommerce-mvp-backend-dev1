using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController: ControllerBase
    {
        private readonly IUserRepository _repository;
        public UsersController()
        {
            _repository = new MockUserRepository();
        }

        [HttpGet()]
        public ActionResult <IEnumerable<User>> GetAllUsers()
        {
            var userItems = _repository.GetAllUser();
            return Ok(userItems);
        }

        [HttpGet("{id}")]
        public ActionResult <User> GetUserById(int id)
        {
            var userItem = _repository.GetUserById(id);
            return Ok(userItem);
        }
    }
}