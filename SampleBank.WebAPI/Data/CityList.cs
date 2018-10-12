
using SampleBank.WebAPI.Models;
using System.Collections.Generic;

namespace SampleBank.WebAPI.Data
{
    public class CityList
    {
        public static List<City> list = new List<City>
        {
            new City { Id = 1, Name = "Akola", Description = "Akola" },
            new City { Id = 2, Name = "Amaravati", Description = "Amaravati" },
            new City { Id = 3, Name = "Maharashtra", Description = "Maharashtra" },
            new City { Id = 4, Name = "Pune", Description = "Pune" },
            new City { Id = 5, Name = "Ratnagiri", Description = "Ratnagiri" }
        };
    }
}
