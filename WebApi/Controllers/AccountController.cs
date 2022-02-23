using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController: ControllerBase
    {
        private readonly IUsersRepository _repository;
        private readonly IMapper _mapper;

        public AccountController(IUsersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost()]
        public ActionResult <User> GetUserByEmail(UserLoginDto userLoginDto)
        {   
            int errorCount = 0;
            User userGetData = null;
            if(userLoginDto.Email != null) {
                userGetData = _repository.GetUserByEmail(userLoginDto.Email);
                if(userGetData != null){
                    if(userGetData.Password == userLoginDto.Password)
                    {
                        errorCount = 0;
                    } else {
                        errorCount += 1;// Si la contraseña no coincide
                    }
                } else {
                    errorCount += 1; // Si no existe registro asociado al correo
                }
            } else {
                errorCount += 1; // Si el correo es nulo
            }

            if(errorCount > 0) {
                return Unauthorized();
            } else {
                return Ok(_mapper.Map<UserReadDto>(userGetData));
            }

        }
    }
}