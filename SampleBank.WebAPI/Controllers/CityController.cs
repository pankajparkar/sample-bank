using System.Collections.Generic;
using System.Web.Http;
using SampleBank.DAL;
using SampleBank.DAL.Repository;
using SampleBank.DAL.Models;

namespace SampleBank.WebAPI.Controllers
{
    public class CityController : ApiController
    {
        private ICityRepository _cityRepository;

        public CityController() {
            _cityRepository = new CityRepository();
        }

        public City Get(int id) => new City();

        public List<City> GetAll()
        {
            var cities = _cityRepository.GetAll();
            return cities;
        }

        ~CityController() {
            _cityRepository = null;
        }
    }
}