using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SampleBank.WebAPI.Data;
using SampleBank.DAL;
using SampleBank.DAL.Repository;
using SampleBank.DAL.Models;

namespace SampleBank.WebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        private ICustomerRepository _customerRepository;
        public CustomerController()
        {
            _customerRepository = new CustomerRepository();
        }

        public List<Customer> GetAll(string name, CustomerType? customerType, int? cityId)
        {
            var result = _customerRepository.GetAll(name, customerType, cityId);
            return result;
        }

        public Customer Get(int id)
        {
            var customers = _customerRepository.GetAll(null, null, null);
            var customer = customers.FirstOrDefault(i => i.Id == id);
            return customer;
        }

        public Customer Post(Customer customer) {
            Customer cust;
            if(customer.Id <= 0)
                cust = _customerRepository.CreateCustomer(customer);
            else 
                cust = _customerRepository.UpdateCustomer(customer);
            return cust;
        }
    }
}
