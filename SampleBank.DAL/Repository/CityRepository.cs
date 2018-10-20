using System.Collections.Generic;
using SampleBank.WebAPI.Models;

namespace SampleBank.DAL.Repository
{
    class CityRepository : ICityRepository
    {
        public List<City> GetAll()
        {
            var sqlHelper = new Core.SQLHelper();
            return new List<City>();
        }
    }
}
