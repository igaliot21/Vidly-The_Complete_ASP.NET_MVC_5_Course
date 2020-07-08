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
        public ActionResult New()
        {
            return View("CustomerForm", new CustomerFormViewModel(new Customer(), context.MenbershipTypes.ToList()));
        }
        public ActionResult Edit(int? Id)
        {
            Customer customer = context.Customers.Include(c => c.MenbershipType).SingleOrDefault(c => c.Id == Id);
            if (customer == null) return HttpNotFound();
            else return View("CustomerForm", new CustomerFormViewModel(customer, context.MenbershipTypes.ToList()));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("CustomerForm", new CustomerFormViewModel(customer, context.MenbershipTypes.ToList()));
            }
            else { 
                if (customer.Id == 0)
                {
                    context.Customers.Add(customer);
                }
                else
                {
                    Customer editCustomer = context.Customers.Single(c => c.Id == customer.Id);
                    editCustomer.Name = customer.Name;
                    editCustomer.Birthdate = customer.Birthdate;
                    editCustomer.MenbershipTypeId = customer.MenbershipTypeId;
                    editCustomer.IsSucribedToNewsletter = customer.IsSucribedToNewsletter;

                }
                context.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }
        }
    }
}