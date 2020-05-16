using Journey.API.Infrastructure;
using Journey.Application.Account;
using Journey.Application.Account.Request;
using Journey.Application.Account.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Journey.API.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly IAccountService AccountService;
        private readonly ILogger<CustomerController> Logger;
        public CustomerController(IAccountService accountService,
            ILogger<CustomerController> logger,
            IConfiguration configuration)
            : base(configuration)
        {
            this.AccountService = accountService;
            this.Logger = logger;
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUpCustomer([FromBody]CustomerSignUpRequest userRequest)
        {
            Logger.LogInformation($"Registration request received with {userRequest.EmailAddress}");

            CustomerSignUpResponse response = await AccountService.SignUpCustomerAsync(userRequest);

            return Created(GetPath($"/api/customer/{response.CustomerId}"), response);
        }

        [HttpPut]
        [Route("verification/otp/{customerId:int}")]
        public async Task<IActionResult> VerifyOTP(int customerId, [FromBody]OTPVerificationRequest otpVerificationRequest)
        {
            Logger.LogInformation($"Received OTP {otpVerificationRequest.OTP} of customer {customerId} for verification");
            return Ok();
        }

        /*
         /customer/signup -  POST
/customer/verification/otp/{customerid} - PUT {"OTP":""}
/customer/otp/{customerid}  - GET 
/customer/verification/email/{customerid}  {"EmailGeneratedTime":2020-05-10 10:00:00} - PUT
/customer/verification-email/{customerid} - GET
         */

    }
}