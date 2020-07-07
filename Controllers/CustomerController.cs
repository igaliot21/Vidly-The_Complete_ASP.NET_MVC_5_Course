using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;


namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {

        private ApplicationDbContext context;
        //List<Customer> customers;
        public CustomerController(){
            context = new ApplicationDbContext();
            /*
            customers = new List<Customer>();
            customers.Add(new Customer(1, "Jerome Morrow",false, new MenbershipType()));
            customers.Add(new Customer(2, "Ellen Ripley",false, new MenbershipType()));
            customers.Add(new Customer(3, "Bud White",false, new MenbershipType()));
            */
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            context.Dispose();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var viewModel = new CustomerListViewModel(context.Customers.Include(c => c.MenbershipType).ToList());
            return View(viewModel);
        }
        public ActionResult GetCustomer(int? Id) 
        {
            //Customer customer = customers.Find(c => c.Id == Id);
            Customer customer = context.Customers.Include(c => c.MenbershipType).SingleOrDefault(c => c.Id == Id);
            if (customer == null) return HttpNotFound();
            else return View(customer);
        }
    }
}