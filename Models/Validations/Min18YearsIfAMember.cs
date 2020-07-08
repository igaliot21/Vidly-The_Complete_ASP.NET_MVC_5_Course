using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Helpers;

namespace Vidly.Models.Validations
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = validationContext.ObjectInstance as Customer;
            if (customer.MenbershipTypeId == MenbershipType.PayAsYouGo || 
                customer.MenbershipTypeId == MenbershipType.Unknown) return ValidationResult.Success;
            else {
                if (customer.Birthdate == null) return new ValidationResult("Birthday is required");
                else {
                    var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
                    if (age >= 18) return ValidationResult.Success;
                    else return new ValidationResult("Customer must be at leat 18 year old for this membership type");
                }
            }
        }
    }
}