using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journey.API.Infrastructure
{
    public class ErrorModel
    {
        public object ErrorMessage { get; private set; }
        public int StatusCode { get; set; }
        public ErrorModel(int statusCode,object message)
        {
            StatusCode = statusCode;
            ErrorMessage = message;
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
