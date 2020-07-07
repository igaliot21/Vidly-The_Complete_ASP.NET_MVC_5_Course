using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        List<Customer> customers;
        public CustomerController(){
            customers = new List<Customer>();
            customers.Add(new Customer(1, "Jerome Morrow"));
            customers.Add(new Customer(2, "Ellen Ripley"));
            customers.Add(new Customer(3, "Bud White"));
        }
        // GET: Customer
        public ActionResult Index()
        {
            var viewModel = new CustomerListViewModel(customers);
            return View(viewModel);
        }
        public ActionResult GetCustomer(int? Id) 
        {
            Customer customer = customers.Find(c => c.Id == Id);
            if (customer == null) return HttpNotFound();
            else return View(customer);
        }
    }
}