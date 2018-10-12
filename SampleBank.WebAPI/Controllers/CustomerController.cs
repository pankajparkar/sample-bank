using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SampleBank.WebAPI.Models;

namespace SampleBank.WebAPI.Controllers
{
    [Route("customer")]
    public class CustomerController : ApiController
    {
        public Customer Get(int id)
        {
            return CustomerList.list.FirstOrDefault(i => i.Id == id);
        }

        [Route("list")]
        public IEnumerable<Customer> GetAll()
        {
            if(CustomerList.list.Count == 0){
                CustomerList.list.Add(new Customer(1, "Pankaj", 10000, true, CustomerType.Current, 1, 400072));
                CustomerList.list.Add(new Customer(1, "Pankaj", 10000, true, CustomerType.Current, 1, 400072));
                CustomerList.list.Add(new Customer(1, "Pankaj", 10000, true, CustomerType.Current, 1, 400072));
                CustomerList.list.Add(new Customer(1, "Pankaj", 10000, true, CustomerType.Current, 1, 400072));
                CustomerList.list.Add(new Customer(1, "Pankaj", 10000, true, CustomerType.Current, 1, 400072));
                CustomerList.list.Add(new Customer(1, "Pankaj", 10000, true, CustomerType.Current, 1, 400072));
            }
            return CustomerList.list;
        }

        public Customer Post(Customer customer) {
            if (customer.Id <= 0) {
                throw new ApplicationException("Id field is required");
            }
            var existingCustomer = CustomerList.list.FirstOrDefault(c => c.Id == customer.Id);
            // If it is new customer then create new object and assign new Id
            if (existingCustomer == null) {
                existingCustomer = new Customer { 
                    Id = 1
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
