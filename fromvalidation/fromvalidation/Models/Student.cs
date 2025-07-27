using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using fromvalidation.Models;

namespace FormSubmission.Models
{
    public class Student
    {
        [Required]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]$",ErrorMessage = "id should be this format XX-XXXXX-X")]
        public string Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\s.-]+$",ErrorMessage ="name can only contain alphabet,space,dot,dash")]
        public string Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Username must be between 5 and 20 characters.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "Username cannot contain spaces.")]
        public string UName { get; set; }
        [Required]
        [Age(18)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Email Needed")]
        [EmailAddress]
        [mailAttribute]
        public string Email { get; set; }
    }
}