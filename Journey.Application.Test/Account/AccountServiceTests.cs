using Journey.Application.Account;
using Journey.Application.Account.Request;
using Journey.Application.Account.Response;
using Journey.Domain.Model.Customer;
using Journey.Infrastructure.Common;
using Journey.Infrastructure.SMS;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Journey.Application.Test.Account
{
    public class AccountServiceTests
    {
        private Mock<ICustomerService> CustomerServiceMock = new Mock<ICustomerService>();
        private Mock<ISMSService> SMSServiceMock = new Mock<ISMSService>();
        private Mock<ICustomerRepository> CustomerRepositoryMock = new Mock<ICustomerRepository>();
        private Mock<ISharedUtilities> SharedUtilitiesMock = new Mock<ISharedUtilities>();
        private Mock<ILogger<AccountService>> LoggerMock = new Mock<ILogger<AccountService>>();

        [Fact]
        public async Task SignUpCustomerAysnc_success()
        {
            // arrange
            int customerId = 1;
            long otp = 965876;
            DateTime validUpTo = DateTime.UtcNow.AddMinutes(5);
            CustomerSignUpRequest userSignUpRequest = new CustomerSignUpRequest
            {
                EmailAddress = "dinesh.p@thinkpalm.com",
                Password = "Think@123",
                PhoneCode = "+91",
                PhoneNumber = "9544856521"
            };
            CustomerSignUpResult signUpResult = new CustomerSignUpResult(customerId);

            CustomerServiceMock.Setup(service => service.SignUpCustomerAsync(It.IsAny<Customer>())).Returns(Task.FromResult<CustomerSignUpResult>(signUpResult));
            SharedUtilitiesMock.Setup(utilities => utilities.GenerateOTPHaving(6)).Returns(otp);
            CustomerRepositoryMock.Setup(repository => repository.GenerateSignUpOTPAsync(It.IsAny<CustomerOTP>())).Returns(Task.FromResult<bool>(true));
            AccountService accountService = new AccountService(CustomerServiceMock.Object, 
                SMSServiceMock.Object, 
                CustomerRepositoryMock.Object, 
                SharedUtilitiesMock.Object, 
                LoggerMock.Object);

            // act
            CustomerSignUpResponse response = await accountService.SignUpCustomerAsync(userSignUpRequest);

            // assert
            Assert.Equal(customerId, response.CustomerId);

        }
        [Fact]
        public async Task SignUpCustomerAysnc_failed()
        {
            try
            {
                // arrange
                int customerId = 0;
                long otp = 965876;
                DateTime validUpTo = DateTime.UtcNow.AddMinutes(5);
                CustomerSignUpRequest userSignUpRequest = new CustomerSignUpRequest
                {
                    EmailAddress = "dinesh.p@thinkpalm.com",
                    Password = "Think@123",
                    PhoneCode = "+91",
                    PhoneNumber = "9544856521"
                };
                CustomerSignUpResult signUpResult = new CustomerSignUpResult(customerId);

                CustomerServiceMock.Setup(service => service.SignUpCustomerAsync(It.IsAny<Customer>())).Returns(Task.FromResult<CustomerSignUpResult>(signUpResult));
                SharedUtilitiesMock.Setup(utilities => utilities.GenerateOTPHaving(6)).Returns(otp);
                CustomerRepositoryMock.Setup(repository => repository.GenerateSignUpOTPAsync(It.IsAny<CustomerOTP>())).Returns(Task.FromResult<bool>(true));
                AccountService accountService = new AccountService(CustomerServiceMock.Object,
                    SMSServiceMock.Object,
                    CustomerRepositoryMock.Object,
                    SharedUtilitiesMock.Object,
                    LoggerMock.Object);

                // act
                CustomerSignUpResponse response = await accountService.SignUpCustomerAsync(userSignUpRequest);

                // assert
                Assert.Null(response);
            }
            catch (Exception ex)
            {
                Assert.Equal(typeof(CustomerSignUpFailedException), ex.GetType());
            }

        }
    }
}
