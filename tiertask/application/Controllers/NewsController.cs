using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace application.Controllers
{
    public class NewsController : ApiController
    {
        [RoutePrefix("api/news")]
        public class StudentController : ApiController
        {
            [HttpGet]
            [Route("all")]
            public HttpResponseMessage Get()
            {
                var data = NewsService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            [HttpGet]
            [Route("{id}")]
            public HttpResponseMessage Get(int id)
            {
                var data = new NewsService().Get(id);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No News Found");

            }
            
        }
    }
}
