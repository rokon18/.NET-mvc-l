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
    [RoutePrefix("api/departments")]
    public class DepartmentController : ApiController
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
                var departments = GetMapper().Map<List<DepartmentDTO>>(db.Departments.ToList());
                return Request.CreateResponse(HttpStatusCode.OK, departments);
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
                var dept = GetMapper().Map<DepartmentDTO>(db.Departments.Find(id));
                return Request.CreateResponse(HttpStatusCode.OK, dept);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage create(DepartmentDTO s)
        {
            var dept = GetMapper().Map<Department>(s);
            try
            {
                db.Departments.Add(dept);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created, dept);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, ex.Message);
            }

        }
        [HttpPost]
        [Route("edit")]
        public HttpResponseMessage edit(DepartmentDTO s)
        {
            var dept = GetMapper().Map<Department>(s);
            try
            {
                var d = db.Departments.Find(dept.Id);
                if (d != null)
                {
                    d.DeptName = dept.DeptName;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, d);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Department not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, ex.Message);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage delete(int id)
        {
            try
            {
                var d = db.Departments.Find(id);
                if (d != null)
                {
                    db.Departments.Remove(d);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Department not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, ex.Message);
            }
        }
        [HttpGet]
        [Route("withstudents")]
        public HttpResponseMessage GetDepartmentStudents()
        {
            try
            {
                var departments = db.Departments.Include("Students").ToList();
                var result = GetMapper().Map<List<DepartmentStudentDTO>>(departments);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, ex.Message);
            }
        }
        [HttpGet]
        [Route("withstudents/{id}")]
        public HttpResponseMessage GetDepartmentStudents(int id)
        {
            try
            {
                var department = db.Departments.Include("Students").SingleOrDefault(d => d.Id == id);
                if (department != null)
                {
                    var result = GetMapper().Map<DepartmentStudentDTO>(department);
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Department not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, ex.Message);
            }
        }
    }
}
