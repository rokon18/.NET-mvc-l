using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_intro.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cgpa { get; set; }
        public int D_Id { get; set; }
    }
}