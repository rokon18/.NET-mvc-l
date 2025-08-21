using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;

namespace api_intro.Controllers
{
    [RoutePrefix("api")]
    public class apiController : ApiController
    {
        // GET api/<controller>

        [HttpGet]
        [Route("get")]
        public HttpResponseMessage Get()
        {

            return Request.CreateResponse(HttpStatusCode.OK, "Hello, get!");
            
        }
        [Route("get1")]
        public HttpResponseMessage get1()
        {

            return Request.CreateResponse(HttpStatusCode.OK, "Hello, get1!");

        }
        [Route("postc")]
        public HttpResponseMessage postcalled()
        {

            return Request.CreateResponse(HttpStatusCode.OK, "Hello, post!");

        }
    }
}
