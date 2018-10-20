using SampleBank.WebAPI.Models;
using System.Collections.Generic;

namespace SampleBank.DAL
{
    interface ICityRepository
    {
        List<City> GetAll();
    }
}
