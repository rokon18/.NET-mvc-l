using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_intro.DTOs
{
    public class StudentDeptDTO : StudentDTO
    {
        public DepartmentDTO Department { get; set; }
    }
}