using BLL;
using BLL.DTOs;
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
            [HttpGet]
            [Route("bydate/{date}")]
            public HttpResponseMessage Get(DateTime date)
            {
                var data = new NewsService().Get(date);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No News Found");
            }
            [HttpGet]
            [Route("bydate/{date}/bycategory/{cname}")]
            public HttpResponseMessage Get(DateTime date, string cname)
            {
                var data = new NewsService().Get(date,  new CategoryDTO { Name = cname });
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No News Found");
            }
            [HttpGet]
            [Route("bycategory/{cname}")]
            public HttpResponseMessage Get(string cname)
            {
                var data = new NewsService().Get(new CategoryDTO { Name = cname });
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No News Found");
            }
            [HttpDelete]
            [Route("delete/{id}")]
            public HttpResponseMessage Delete(int id)
            {
                var data = new NewsService().Delete(id);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "News Deleted");
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No News Found");
            }
            [HttpGet]
            [Route("update")]
            public HttpResponseMessage Update(NewsDTO n)
            {
                var data = new NewsService().Update(n);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "News Updated");
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No News Found");
            }

        }
    }
}
