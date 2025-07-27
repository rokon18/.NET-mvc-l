using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fromvalidation.Models
{
    public class Age : ValidationAttribute
    {
        private int _age_limit;
        public Age(int age_limit)
        {
            _age_limit = age_limit;

        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var Date = (DateTime)value;
                double age = (DateTime.Now - Date).TotalDays / 365;
                if (age < _age_limit)
                { return new ValidationResult("age must be 18"); }
            }

                return ValidationResult.Success;
            
        }
    }
}