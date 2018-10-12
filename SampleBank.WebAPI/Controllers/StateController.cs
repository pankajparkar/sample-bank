using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SampleBank.WebAPI.Models;
using SampleBank.WebAPI.Data;

namespace SampleBank.WebAPI.Controllers
{
    public class CityController : ApiController
    {
        public City Get(int id) {
            return CityList.list.FirstOrDefault(i => i.Id == id);
        }

        public List<City> GetAll()
        {
            return CityList.list;
        }
    }
}