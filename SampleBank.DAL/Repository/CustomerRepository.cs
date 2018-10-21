using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using SampleBank.DAL.Models;

namespace SampleBank.DAL.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

        private Customer createCustomerObject (SqlDataReader rdr)
        {
            var customer = new Customer()
            {
                Id = rdr.GetInt32(0),
                Guid = rdr.GetGuid(1),
                FirstName = rdr.GetValue(2).ToString(),
                LastName = !rdr.IsDBNull(3) ? rdr.GetValue(3).ToString() : "",
                Balance = rdr.GetDecimal(4),
                CustomerType = rdr.GetValue(5).ToString() == "Saving" ? CustomerType.Saving : CustomerType.Current,
                Gender = rdr.GetValue(6).ToString() == "Male" ? GenderEnum.Male : GenderEnum.Female,
                IsActive = rdr.GetBoolean(7),
                PinCode = !rdr.IsDBNull(8) ? rdr.GetInt32(8) : (int?)null,
                CityId = rdr.GetInt32(0),
            };
            return customer;
        }

        private object getValueOrNull(object value)
        {
            return value != null ? value : DBNull.Value;
        }

        public List<Customer> GetAll(string name, CustomerType? customerType, int? cityId)
        {
            var customers = new List<Customer>();
            var query = "EXEC GetCustomers";
            using (SQLHelper db = new SQLHelper(connectionString))
            using (SqlDataReader rdr = db.ExecDataReader(query, "@Name", getValueOrNull(name), "@CustomerType", getValueOrNull(customerType), "@CityId", getValueOrNull(cityId)))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        customers.Add(createCustomerObject(rdr));
                    }
                }
            }
            return customers;
        }

        public Customer GetCustomer(int id)
        {
            Customer customer = new Customer();
            var query = "EXEC GetCustomer";
            using (SQLHelper db = new SQLHelper(connectionString))
            using (SqlDataReader rdr = db.ExecDataReader(query, id))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        customer = createCustomerObject(rdr);
                    }
                }
            }
            return customer;
        }

        public Customer UpdateCustomer(Customer customer) {
            var existingCustomer = GetCustomer(customer.Id);
            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.Balance = customer.Balance;
            existingCustomer.CustomerType = customer.CustomerType;
            existingCustomer.CityId = customer.CityId;
            existingCustomer.PinCode = customer.PinCode;
            var query = "EXEC UpdateCustomer";
            using (SQLHelper db = new SQLHelper(connectionString))
            {
                // TODO: check for operation completion
                db.ExecNonQuery(query, "@Id", customer.Id, "@FirstName", existingCustomer.FirstName, "@LastName", existingCustomer.LastName, "@Balance", existingCustomer.Balance, "@CustomerType", existingCustomer.CustomerType, "@Gender", existingCustomer.Gender, "@IsActive", existingCustomer.IsActive, "@PinCode", existingCustomer.PinCode, "@CityId", existingCustomer.CityId);
            }
            return customer;
        }

        public Customer CreateCustomer(Customer customer)
        {
            var query = "EXEC CreateCustomer";
            using (SQLHelper db = new SQLHelper(connectionString))
            {
                // TODO: check for operation completion
                db.ExecNonQuery(query, "@Id", customer.Id, "@FirstName", customer.FirstName, "@LastName", customer.LastName, "@Balance", customer.Balance, "@CustomerType", customer.CustomerType, "@Gender", customer.Gender, "@IsActive", customer.IsActive, "@PinCode", customer.PinCode, "@CityId", customer.CityId);
            }
            return customer;
        }
    }
}
