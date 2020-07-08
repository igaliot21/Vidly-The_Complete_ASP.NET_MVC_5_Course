using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        
        public string Name { get; set; }
        
        public bool IsSucribedToNewsletter { get; set; }
        
        public MenbershipType MenbershipType { get; set; }
        
        [Display(Name = "Membership Type")]
        public int MenbershipTypeId { get; set; }
        
        [Display(Name ="Date of Birth")]
        public DateTime? Birthdate { get; set; }
    }
}