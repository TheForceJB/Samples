using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using WL.Sample.Model;
using WL.Sample.Model.Model;

namespace WL.Sample.WebApi.Controllers
{
    public class AdController : ApiController
    {
        [HttpGet]
        //[Queryable]
        [EnableQuery]
        public IQueryable<AdUser> Get()
        {
            List<AdUser> adUsers = new List<AdUser>();
            adUsers.Add(new AdUser { Cn = "JB.Lin", Sn = "Lin", GivenName = "JB", DisplayName = "The Force JB", Age=34, Status = AdUserStatusEnum.New.ToString() });
            adUsers.Add(new AdUser { Cn = "Lily.Yang", Sn = "Yang", GivenName = "Lily", DisplayName = "The Force Lily", Age=18, Status = AdUserStatusEnum.Updated.ToString() });
            adUsers.Add(new AdUser { Cn = "Leia.Lin", Sn = "Lin", GivenName = "Leia", DisplayName = "Leia Skywalker", Age=2, Status = AdUserStatusEnum.New.ToString() });


            return adUsers.AsQueryable();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
