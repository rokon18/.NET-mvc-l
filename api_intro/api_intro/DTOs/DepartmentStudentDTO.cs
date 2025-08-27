using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_intro.DTOs
{
    public class DepartmentStudentDTO : DepartmentDTO
    {
        public List<StudentDTO> Students { get; set; }

    }
}