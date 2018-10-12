using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SampleBank.WebAPI.Models;
using SampleBank.WebAPI.Data;

namespace SampleBank.WebAPI.Controllers
{
    public class StateController : ApiController
    {
        public State Get(int id) {
            return StateList.list.FirstOrDefault(i => i.Id == id);
        }

        public List<State> GetAll()
        {
            return StateList.list;
        }
    }
}