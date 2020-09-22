using CustomerPortal.Business.Interfaces;
using CustomerPortal.Business.Services;
using CustomerPortal.Controllers;
using CustomerPortal.Data;
using CustomerPortal.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MockTests
{
    [TestFixture]
    public class CustomerTest
    {
        private Mock<ICustomerService> _customerServiceMock;
        private IConfigurationRoot configuration;
        private Mock<IUserService> _userServiceMock;
        private readonly ILogger<CustomerController> logger;
        public CustomerTest()
        {
            var mock = new Mock<ILogger<CustomerController>>();
            logger = mock.Object;

            //or use this short equivalent 
            logger = Mock.Of<ILogger<CustomerController>>();
            _customerServiceMock = new Mock<ICustomerService>();
            _userServiceMock = new Mock<IUserService>();
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
        public void ValidFileData()
        {
            // Arrange
            CustomerController customer = new CustomerController(_customerServiceMock.Object,logger,_userServiceMock.Object, configuration);
            List<TblCustomer> cust = new List<TblCustomer>();

            // Act
            IFormFile fileData = uploadfile();
            _customerServiceMock.Setup(x => x.CustomerData(fileData,0)).Returns(cust);
            var result = customer.Post(fileData,0);

            // Assert
            Assert.AreEqual(result, cust);
        }


        private IFormFile uploadfile()
        {
            var fileMock = new Mock<IFormFile>();
            //Setup mock file using a memory stream
            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);

            var file = fileMock.Object;
            return file;
        }


        private List<TblCustomer> getCustomer()
        {
            List<TblCustomer> customers = new List<TblCustomer>();
            TblCustomer customer = new TblCustomer { Id = 1, Name = "Test", CustomerTypeId = 1, Amount = 100, Date = new DateTime() };
            customers.Add(customer);
            return customers;
        }
    }
}
