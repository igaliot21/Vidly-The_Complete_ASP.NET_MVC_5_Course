using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models.Validations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter customer's name")]
        [StringLength(255)]

        public string Name { get; set; }

        public bool IsSucribedToNewsletter { get; set; }

        public MenbershipType MenbershipType { get; set; }

        [Display(Name = "Membership Type")]
        [Required(ErrorMessage = "Please enter customer's Membership Type")]
        public int MenbershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}