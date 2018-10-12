﻿
using System.Collections.Generic;

namespace SampleBank.WebAPI.Models
{
    public class CustomerList
    {
        public static List<Customer> list = new List<Customer>() {
            new Customer { Id = 1, Balance = 10000, CustomerType = CustomerType.Current, IsActive = true, Name = "Pankaj", PinCode = 123456, StateId = 1, Gender = GenderEnum.Male },
            new Customer { Id = 1, Balance = 20000, CustomerType = CustomerType.Saving, IsActive = true, Name = "Prajakta", PinCode = 123456, StateId = 1, Gender = GenderEnum.Female },
            new Customer { Id = 1, Balance = 30000, CustomerType = CustomerType.Current, IsActive = true, Name = "Harsha", PinCode = 123456, StateId = 1, Gender = GenderEnum.Female },
            new Customer { Id = 1, Balance = 40000, CustomerType = CustomerType.Saving, IsActive = true, Name = "Anil", PinCode = 123456, StateId = 1, Gender = GenderEnum.Male },
            new Customer { Id = 1, Balance = 50000, CustomerType = CustomerType.Current, IsActive = true, Name = "Upul", PinCode = 123456, StateId = 1, Gender = GenderEnum.Male },
            new Customer { Id = 1, Balance = 60000, CustomerType = CustomerType.Saving, IsActive = true, Name = "Jack", PinCode = 123456, StateId = 1, Gender = GenderEnum.Male },
        };
    }
}
