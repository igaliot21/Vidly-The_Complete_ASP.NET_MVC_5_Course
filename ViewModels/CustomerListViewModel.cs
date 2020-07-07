using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerListViewModel
    {
        public List<Customer> Customers { get; set; }
        public CustomerListViewModel() { }
        public CustomerListViewModel(List<Customer> Customers)
        {
            this.Customers = Customers;
        }
    }
}