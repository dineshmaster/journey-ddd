using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Journey.API.Infrastructure
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public Uri BaseUri { get; set; }
        public BaseController(IConfiguration configuration)
        {
            this.BaseUri =new Uri(configuration["Application:BaseUri"].ToString());
        }
        public Uri GetPath(string relativeUri)
        {
            Uri uri = new Uri(this.BaseUri, relativeUri);
            return uri;
        }
    }
}