using CustomerPortal.Business.Services;
using CustomerPortal.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserService _userService;
        public IConfiguration _config { get; }
        public LoginController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _config = configuration;
        }

        [HttpPost("authenticate")]
        public string Authenticate([FromBody] User userParam)
        {
            string token;
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return "Invalid data";
            else
            {
                token = _userService.GenerateJSONWebToken(userParam,_config);
            }
            return token;
        }

        
    }
}
