using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SampleBank.WebAPI.Models;

namespace SampleBank.WebAPI.Controllers
{
    [Route("state")]
    public class StateController : ApiController
    {
        public State Get(int id) {
            return StateList.list.FirstOrDefault(i => i.Id == id);
        }

        [Route("list")]
        public List<State> GetAll()
        {
            if (StateList.list.Count <= 0) {
                StateList.list.Add(new State { Id = 1, Name = "Akola", Description = "Akola" });
                StateList.list.Add(new State { Id = 2, Name = "Amaravati", Description = "Amaravati" });
                StateList.list.Add(new State { Id = 1, Name = "Maharashtra", Description = "Maharashtra" });
                StateList.list.Add(new State { Id = 1, Name = "Pune", Description = "Pune" });
                StateList.list.Add(new State { Id = 1, Name = "Ratnagiri", Description = "Ratnagiri" });
            }
            return StateList.list;
        }
    }
}