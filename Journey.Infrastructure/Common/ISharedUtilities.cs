using System;
using System.Collections.Generic;
using System.Text;

namespace Journey.Infrastructure.Common
{
    public interface ISharedUtilities
    {
        long GenerateOTPHaving(int digits=6);
    }
}
