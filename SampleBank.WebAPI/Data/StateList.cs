
using SampleBank.WebAPI.Models;
using System.Collections.Generic;

namespace SampleBank.WebAPI.Data
{
    public class StateList
    {
        public static List<State> list = new List<State>
        {
            new State { Id = 1, Name = "Akola", Description = "Akola" },
            new State { Id = 2, Name = "Amaravati", Description = "Amaravati" },
            new State { Id = 1, Name = "Maharashtra", Description = "Maharashtra" },
            new State { Id = 1, Name = "Pune", Description = "Pune" },
            new State { Id = 1, Name = "Ratnagiri", Description = "Ratnagiri" }
        };
    }
}
