using SampleBank.DAL.Models;
using System.Collections.Generic;

namespace SampleBank.DAL
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();

        Customer UpdateCustomer(Customer customer);

        Customer CreateCustomer(Customer customer);
    }
}
