using System;
using System.Collections.Generic;
using SampleBank.WebAPI.Models;

namespace SampleBank.DAL.Repository
{
    class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetAll() => new List<Customer>();
    }
}
