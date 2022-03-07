using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Customers;
using WebApi.Interfaces;
using WebApi.Services.Interface;

namespace  WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customersService;

        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        [HttpGet("{id}")]
        public ActionResult <CustomerReadDto> GetCustomers(int id)
        {
            return Ok(_customersService.GetCustomerById(id));
        }
    }
}