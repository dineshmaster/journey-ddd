using Journey.API.Controllers;
using Journey.Application.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Journey.API.Test.Controllers
{
    public class CustomerControllerTests
    {
        [Fact]
        public async void SignUpCustomer_success()
        {
            Mock<IAccountService> accountServiceMock = new Mock<IAccountService>();
            Mock<ILogger<CustomerController>> LoggerMock = new Mock<ILogger<CustomerController>>();
            Mock<IConfiguration> configurationMock = new Mock<IConfiguration>();
            int customerId = 300;
            CustomerSignUpResponse response = new CustomerSignUpResponse
            {
                CustomerId = customerId
            };
            configurationMock.SetupGet(p => p["Application.BaseUri"]).Returns("https://localhost:44339/");
            accountServiceMock.Setup(p => p.SignUpCustomerAsync(It.IsAny<CustomerSignUpRequest>())).Returns(Task.FromResult<CustomerSignUpResponse>(response));
            CustomerController customerController = new CustomerController(accountServiceMock.Object, LoggerMock.Object, configurationMock.Object);
            ActionContext context = customerController.ControllerContext;
            CustomerSignUpRequest userSignUpRequest = new CustomerSignUpRequest
            {
                EmailAddress = "dinesh.p@thinkpalm.com",
                Password = "Think@123",
                PhoneCode = "+91",
                PhoneNumber = "9544856521"
            };

            var result = await customerController.SignUpCustomer(userSignUpRequest) as CreatedResult;


            Assert.Equal(typeof(CreatedResult), result.GetType());
            Assert.Equal($"https://localhost:44339/api/customer/{customerId}",result.Location);
            Assert.Equal(201,result.StatusCode);
            Assert.Equal(customerId,((CustomerSignUpResponse)result.Value).CustomerId);
            Assert.True(((CustomerSignUpResponse)result.Value).TwoFARequired);
        }
    }
}
