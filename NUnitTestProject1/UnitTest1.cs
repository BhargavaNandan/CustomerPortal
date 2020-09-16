using CustomerPortal.Business.Services;
using CustomerPortal.Controllers;
using CustomerPortal.Data;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace NUnitTestProject1
{
    [TestFixture]
    public class Tests
    {
        private IUserService _userService;
        public IConfiguration _config { get; }

        //public Tests(IUserService userService, IConfiguration configuration)
        //{
        //    _userService = userService;
        //    _config = configuration;
        //}
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            LoginController login = new LoginController(_userService, _config);
            User user = new User();
            user.Username = "test";
            user.Password = "test";
            string result = login.Authenticate(user).ToString();
            Assert.Pass();
        }
    }
}