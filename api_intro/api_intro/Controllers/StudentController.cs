using api_intro.DTOs;
using api_intro.EF;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_intro.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentController : ApiController
    {
        StudentDbEntities1 db = new StudentDbEntities1();
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();
                cfg.CreateMap<Student, StudentDeptDTO>().ReverseMap();
                cfg.CreateMap<Department, DepartmentDTO>().ReverseMap();
                cfg.CreateMap<Department, DepartmentStudentDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        [Route("all")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var st = GetMapper().Map<List<StudentDTO>>(db.Students.ToList());
                return Request.CreateResponse(HttpStatusCode.OK, st);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [Route("{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var st = GetMapper().Map<StudentDTO>(db.Students.Find(id));
                return Request.CreateResponse(HttpStatusCode.OK, st);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage create( StudentDTO s)
        {
            var st = GetMapper().Map<Student>(s);
            try
            {
                db.Students.Add(st);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created, st);

            }catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, ex.Message);
            }

        }
        [HttpPost]
        [Route("edit")]
        public HttpResponseMessage edit(StudentDTO s)
        {
            var st = GetMapper().Map<StudentDeptDTO>(s);
            try
            {
                var data = db.Students.Find(st.Id);
                if (data != null)
                {
                    data.Name = st.Name;
                    data.Cgpa = st.Cgpa;
                    data.D_Id = st.D_Id;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student Not Found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, ex.Message);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage remove(int id)
        {
            try
            {
                var data = db.Students.Find(id);
                if (data != null)
                {
                    db.Students.Remove(data);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student Not Found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, ex.Message);
            }
        }
        }
}
