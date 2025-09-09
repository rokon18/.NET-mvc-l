using CodeFirst.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodeFirst.Controllers
{
    public class DepartmentController : ApiController
    {
        UMSContext db=new UMSContext();
    }
}
