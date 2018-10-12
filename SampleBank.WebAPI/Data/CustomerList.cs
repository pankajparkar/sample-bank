using System.Collections.Generic;
using SampleBank.WebAPI.Models;

namespace SampleBank.WebAPI.Data
{
    public class CustomerList
    {
        public static List<Customer> list = new List<Customer>() {
            new Customer { Id = 1, Balance = 10000, CustomerType = CustomerType.Current, IsActive = true, FirstName = "Pankaj", PinCode = 123456, CityId = 1, Gender = GenderEnum.Male },
            new Customer { Id = 2, Balance = 20000, CustomerType = CustomerType.Saving, IsActive = true, FirstName = "Prajakta", PinCode = 123456, CityId = 1, Gender = GenderEnum.Female },
            new Customer { Id = 3, Balance = 30000, CustomerType = CustomerType.Current, IsActive = true, FirstName = "Harsha", PinCode = 123456, CityId = 1, Gender = GenderEnum.Female },
            new Customer { Id = 4, Balance = 40000, CustomerType = CustomerType.Saving, IsActive = true, FirstName = "Anil", PinCode = 123456, CityId = 1, Gender = GenderEnum.Male },
            new Customer { Id = 5, Balance = 50000, CustomerType = CustomerType.Current, IsActive = true, FirstName = "Upul", PinCode = 123456, CityId = 1, Gender = GenderEnum.Male },
            new Customer { Id = 6, Balance = 60000, CustomerType = CustomerType.Saving, IsActive = true, FirstName = "Jack", PinCode = 123456, CityId = 1, Gender = GenderEnum.Male }
        };
    }
}
