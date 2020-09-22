using CustomerPortal.Business.Interfaces;
using CustomerPortal.Business.Services;
using CustomerPortal.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
//using System.Web.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerPortal.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;
        private readonly ILogger _logger;
        
        public CustomerController(ICustomerService customerService, ILogger logger, IUserService userService, IConfiguration configuration)
        {
            _customerService = customerService;
            _logger = logger;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public List<TblCustomer> Post(IFormFile file, decimal amount)
        {
            _logger.LogInformation("Post method.");
            return _customerService.CustomerData(file,Convert.ToDecimal(amount));
        }
    }
}
