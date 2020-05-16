using System;
using System.Collections.Generic;
using System.Text;

namespace Journey.Infrastructure.Common
{
    [Serializable]
    public abstract class ExceptionBase:Exception
    {
        public ExceptionBase(string message):base(message)
        {
        }
    }
}
