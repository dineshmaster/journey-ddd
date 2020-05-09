using Journey.API.Infrastructure;
using Journey.Application.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Journey.API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;
        public AccountController(IAccountService accountService,
            ILogger<AccountController> logger,
            IConfiguration configuration)
            :base(configuration)
        {
            this._accountService = accountService;
            this._logger = logger;
        }

        [HttpPost]
        [Route("register/clientuser")]
        public async Task<IActionResult> Register([FromBody]CustomerSignUpRequest userRequest)
        {
            _logger.LogInformation($"Registration request received with {userRequest.EmailAddress}");

            CustomerSignUpResponse response =await _accountService.SignUpCustomerAsync(userRequest);

            return Created(GetPath($"/api/Account/clientUser/{response.CustomerId}"),response);
        }

    }
}