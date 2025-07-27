using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fromvalidation.Models
{
    public class mailAttribute : ValidationAttribute
    {
        public mailAttribute() { }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var email = value.ToString();
                var idProperty = validationContext.ObjectType.GetProperty("Id");
                if (idProperty != null)
                {
                    string idValue = idProperty.GetValue(validationContext.ObjectInstance, null)?.ToString();

                        
                        if (!email.StartsWith(idValue))
                        {
                            return new ValidationResult("Email must start with the f ID.");
                        }
                }
            }

            return ValidationResult.Success;
        }

    }
            
        }
    
