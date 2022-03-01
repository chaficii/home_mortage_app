using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WF4_GetUserState.Controllers
{
    public class HadForeclosureController : ApiController
    {
        // GET: api/HadForeclosure
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/HadForeclosure/5
        public bool Get(int id)
        {
			Data d = new Data();
			return d.hadForeclosure[id];
        }

        // POST: api/HadForeclosure
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/HadForeclosure/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/HadForeclosure/5
        public void Delete(int id)
        {
        }
    }
}
