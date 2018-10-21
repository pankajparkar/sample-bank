using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using SampleBank.DAL.Models;

namespace SampleBank.DAL.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
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
                        customers.Add(new Customer()
                        {
                            Id = rdr.GetInt32(0),
                            Guid = rdr.GetGuid(1),
                            FirstName = rdr.GetValue(2).ToString(),
                            LastName = !rdr.IsDBNull(3) ? rdr.GetValue(3).ToString(): "",
                            Balance = rdr.GetDecimal(4),
                            CustomerType = rdr.GetValue(5).ToString() == "Saving" ? CustomerType.Saving: CustomerType.Current,
                            Gender = rdr.GetValue(6).ToString() == "Male" ? GenderEnum.Male: GenderEnum.Female,
                            IsActive = rdr.GetBoolean(7),
                            PinCode = !rdr.IsDBNull(8) ? rdr.GetInt32(8) : (int?) null,
                            CityId = rdr.GetInt32(0),
                        });
                    }
                }
            }
            return customers;
        }
    }
}
