using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MenbershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
        public CustomerFormViewModel() { }
        public CustomerFormViewModel(Customer Customer, IEnumerable<MenbershipType> MembershipTypes)
        {
            this.Customer = Customer;
            this.MembershipTypes = MembershipTypes;
        }
    }
}