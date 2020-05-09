using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Journey.Infrastructure.SMS.Twilo
{
    public class TwilioSMSService : ISMSService
    {
        private readonly ILogger<TwilioSMSService> Logger;
        public TwilioSMSService(ILogger<TwilioSMSService> logger)
        {
            this.Logger = logger;
        }
        public void SendSMS(string sendText, string sendTo)
        {
            Logger.LogInformation($"SMS content '{sendText}' is send to '{sendTo}'");
        }
    }
}
