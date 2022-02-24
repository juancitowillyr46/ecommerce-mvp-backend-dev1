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

        [HttpPost("login")]
        public ActionResult <UserReadDto> LoginUser(UserRequestLoginDto userLoginDto)
        {   
            int errorCount = 0;
            User userModel = null;
            if(userLoginDto.Email != null) {
                userModel = _repository.GetUserByEmail(userLoginDto.Email);
                if(userModel != null){
                    bool verify = BCrypt.Net.BCrypt.Verify(userLoginDto.Password, userModel.Password);
                    if(verify)
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
                return Ok(_mapper.Map<UserReadDto>(userModel));
            }

        }

        [HttpPost("register")]
        public ActionResult <UserReadDto> RegisterUser(UserRequestRegisterDto userRegisterDto)
        {
            
            var userModel = _mapper.Map<User>(userRegisterDto);
            userModel.Username = userRegisterDto.Email;
            userModel.CreatedOn = System.DateTime.Now;
            userModel.Block = false;
            userModel.Password = BCrypt.Net.BCrypt.HashPassword(userRegisterDto.Password);

            _repository.CreateUser(userModel);
            _repository.SaveChanges();

            var userReadDto = _mapper.Map<UserReadDto>(userModel);
            return Ok(userReadDto);
        }
    }
}