using SampleBank.WebAPI.Data;
using SampleBank.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SampleBank.WebAPI.Controllers
{
    public class SearchController : ApiController
    {
        public IEnumerable<Customer> Get(string name, CustomerType? customerType = null, int? cityId = null)
        {
            var result = CustomerList.list;
            if (!String.IsNullOrWhiteSpace(name))
                result = result.FindAll(i => i.FirstName == name || i.LastName == name);
            if (customerType != null)
                result = result.FindAll(i => i.CustomerType == customerType);
            if (cityId != null)
                result = result.FindAll(i => i.CityId == cityId);
            return result;
        }
    }
}