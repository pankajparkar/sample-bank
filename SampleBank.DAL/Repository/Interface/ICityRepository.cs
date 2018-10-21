using SampleBank.DAL.Models;
using System.Collections.Generic;

namespace SampleBank.DAL
{
    public interface ICityRepository
    {
        List<City> GetAll();
    }
}
