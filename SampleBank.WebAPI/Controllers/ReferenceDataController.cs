using SampleBank.WebAPI.Data;
using SampleBank.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SampleBank.WebAPI.Controllers
{
    public class ReferenceDataController : ApiController
    {
        [Route("gender/list")]
        public IEnumerable<DropdownValue> Get()
        {
            return ReferenceDataList.gender;
        }

        [Route("accountType/list")]
        public IEnumerable<DropdownValue> GetAccountType()
        {
            return ReferenceDataList.accountTypes;
        }
    }
}