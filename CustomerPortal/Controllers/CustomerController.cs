using CustomerPortal.Business.Interfaces;
using CustomerPortal.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerPortal.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;
        private readonly ILoggerManager _logger;
        
        public CustomerController(ICustomerService customerService, ILoggerManager logger, IUserService userService, IConfiguration configuration)
        {
            _customerService = customerService;
            _logger = logger;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult Post(IFormFile file, decimal amount)
        {
            _logger.LogInfo("Post method.");
            return Ok(_customerService.CustomerData(file,Convert.ToDecimal(amount)));
        }        
    }
}
