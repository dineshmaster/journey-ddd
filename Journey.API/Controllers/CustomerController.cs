using Journey.API.Infrastructure;
using Journey.Application.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Journey.API.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(IAccountService accountService,
            ILogger<CustomerController> logger,
            IConfiguration configuration)
            :base(configuration)
        {
            this._accountService = accountService;
            this._logger = logger;
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUpCustomer([FromBody]CustomerSignUpRequest userRequest)
        {
            _logger.LogInformation($"Registration request received with {userRequest.EmailAddress}");

            CustomerSignUpResponse response =await _accountService.SignUpCustomerAsync(userRequest);

            return Created(GetPath($"/api/customer/{response.CustomerId}"),response);
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