using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SampleBank.WebAPI.Models;
using SampleBank.WebAPI.Data;

namespace SampleBank.WebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        public IEnumerable<Customer> GetAll()
        {
            return CustomerList.list;
        }

        public Customer Get(int id)
        {
            return CustomerList.list.FirstOrDefault(i => i.Id == id);
        }

        public Customer Post(Customer customer) {
            if (customer.Id <= 0) {
                throw new ApplicationException("Id field is required");
            }
            var existingCustomer = CustomerList.list.FirstOrDefault(c => c.Id == customer.Id);
            // If it is new customer then create new object and assign new Id
            if (existingCustomer == null) {
                var id = CustomerList.list.Max(i => i.Id);
                existingCustomer = new Customer { 
                    Id = ++id
                };
            }
            existingCustomer.Name = customer.Name; 
            existingCustomer.Balance = customer.Balance; 
            existingCustomer.CustomerType = customer.CustomerType; 
            existingCustomer.StateId = customer.StateId;
            existingCustomer.PinCode = customer.PinCode;
            return existingCustomer;
        }
    }
}
