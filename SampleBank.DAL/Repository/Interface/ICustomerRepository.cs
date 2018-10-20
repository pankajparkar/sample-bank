using SampleBank.WebAPI.Models;
using System.Collections.Generic;

namespace SampleBank.DAL
{
    interface ICustomerRepository
    {
        List<Customer> GetAll();
    }
}
