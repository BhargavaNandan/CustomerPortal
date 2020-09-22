using CustomerPortal.Business.Services;
using CustomerPortal.Controllers;
using CustomerPortal.Data;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MockTests
{
    [TestFixture]
    public class LoginTest
    {
        private Mock<IUserService> _userServiceMock;
        private Mock<LoginController> _loginControllerMock;
        private IConfigurationRoot configuration;
        public LoginTest()
        {
            _userServiceMock = new Mock<IUserService>();
            _loginControllerMock = new Mock<LoginController>();
            configuration = new ConfigurationBuilder()
            .SetBasePath("E:/Practise/VL/CustomerPortal")
            .AddJsonFile("appsettings.json")
            .Build();
        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidUser()
        {
            // Arrange
            LoginController login = new LoginController(_userServiceMock.Object, configuration);
            User user = getUser();

            // Act
            _userServiceMock.Setup(x => x.Authenticate(user.Username, user.Password)).Returns("");
            _userServiceMock.Setup(x => x.GenerateJSONWebToken(user,configuration)).Returns("valid token");
            string successMessage = "valid token";
            var result = login.Authenticate(user);

            // Assert
            Assert.AreEqual(result, successMessage);
        }

        [Test]
        public void InValidUser()
        {
            // Arrange
            LoginController login = new LoginController(_userServiceMock.Object, configuration);
            User user = new User();

            // Act
            _userServiceMock.Setup(x => x.Authenticate(It.IsAny<string>(), It.IsAny<string>())).Returns("");
            _userServiceMock.Setup(x => x.GenerateJSONWebToken(user, configuration)).Returns("Invalid token");
            string successMessage = "Invalid token";
            var result = login.Authenticate(user);

            // Assert
            Assert.AreEqual(result, successMessage);
        }

        private User getUser()
        {
            User user = new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" };
            return user;
        }

        
    }
}