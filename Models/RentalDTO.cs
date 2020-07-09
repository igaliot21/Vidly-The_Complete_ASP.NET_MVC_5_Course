using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class RentalDTO
    {
        public int customerid { get; set; }
        public List<int> movieids { get; set; }
    }
}