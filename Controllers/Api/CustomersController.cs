﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext context;
        public CustomersController() {
            context = new ApplicationDbContext();
        }
        // GET /api/customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = context.Customers.Include(c => c.MenbershipType);

            if (!string.IsNullOrWhiteSpace(query)) {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }

            var customers = customersQuery.ToList();

            return Ok(customers);
        }
         // GET /api/customers/1
        public IHttpActionResult GetCustomer(int Id){
            var customer = context.Customers.Include(c => c.MenbershipType).Single(c => c.Id == Id);
            if (customer == null) return NotFound();
            else return Ok(customer);
        }
        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer){
            if (!ModelState.IsValid) return BadRequest();
            else
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                return Created(new Uri(Request.RequestUri + "/" + customer.Id), customer);
            }
        }
        // PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int Id, Customer customer) {
            if (!ModelState.IsValid) return BadRequest();
            else
            {
                var customerToEdit = context.Customers.Single(c => c.Id == Id);
                if (customerToEdit == null) return NotFound();
                else
                {
                    customerToEdit.Name = customer.Name;
                    customerToEdit.Birthdate = customer.Birthdate;
                    customerToEdit.IsSucribedToNewsletter = customer.IsSucribedToNewsletter;
                    customerToEdit.MenbershipTypeId = customer.MenbershipTypeId;

                    context.SaveChanges();

                    return Ok(customerToEdit); ;
                }
            }
        }
        // DELETE /api/customer/1
        [HttpDelete]
        public void DeleteCustomer(int Id) { 
            var customerToDelete = context.Customers.Single(c => c.Id == Id);
            if (customerToDelete == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            else {
                context.Customers.Remove(customerToDelete);
                context.SaveChanges();
            }
        }
    }
}
