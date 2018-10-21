using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using SampleBank.DAL.Models;

namespace SampleBank.DAL.Repository
{
    public class CityRepository : ICityRepository
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        public List<City> GetAll()
        {
            var cities = new List<City>();
            var query = "EXEC GetCities";
            using (SQLHelper db = new SQLHelper(connectionString))
            using (SqlDataReader rdr = db.ExecDataReader(query))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        cities.Add(new City()
                        {
                            Id = rdr.GetInt32(0),
                            Name = rdr.GetValue(1).ToString(),
                            Description = rdr.GetValue(2).ToString()
                        });
                    }
                }
            }
            return cities;
        }
    }
}
