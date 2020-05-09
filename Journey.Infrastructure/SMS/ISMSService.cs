using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Journey.Infrastructure.SMS
{
    public interface ISMSService
    {
        void SendSMS(string sendText, string sendTo);
    }
}
