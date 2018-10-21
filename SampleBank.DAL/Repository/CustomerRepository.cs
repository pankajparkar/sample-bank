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

        public List<Customer> GetAll()
        {
            var customers = new List<Customer>();
            var query = "EXEC GetCustomers";
            using (SQLHelper db = new SQLHelper(connectionString))
            using (SqlDataReader rdr = db.ExecDataReader(query))
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
                db.ExecNonQuery(query, customer.Id, existingCustomer.FirstName, existingCustomer.LastName, existingCustomer.Balance, existingCustomer.CustomerType, existingCustomer.Gender, existingCustomer.IsActive, existingCustomer.PinCode, existingCustomer.CityId);
            }
            return customer;
        }

        public Customer CreateCustomer(Customer customer)
        {
            var query = "EXEC CreateCustomer";
            using (SQLHelper db = new SQLHelper(connectionString))
            {
                // TODO: check for operation completion
                db.ExecNonQuery(query, customer.Id, customer.FirstName, customer.LastName, customer.Balance, customer.CustomerType, customer.Gender, customer.IsActive, customer.PinCode, customer.CityId);
            }
            return customer;
        }
    }
}
