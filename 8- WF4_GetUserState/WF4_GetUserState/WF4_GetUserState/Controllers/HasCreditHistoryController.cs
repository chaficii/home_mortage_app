using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WF4_GetUserState.Controllers
{
    public class HasCreditHistoryController : ApiController
    {
        // GET: api/HasCreditHistory
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/HasCreditHistory/5
        public bool Get(int id)
        {
			Data d = new Data();
			return d.hasCreditHistory[id];
        }

        // POST: api/HasCreditHistory
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/HasCreditHistory/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/HasCreditHistory/5
        public void Delete(int id)
        {
        }
    }
}