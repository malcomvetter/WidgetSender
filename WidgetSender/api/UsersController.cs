using System.Collections.Generic;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1
{
    public class UsersController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<AppUser> Get()
        {
            var model = new ManageUsersViewModel();
            return model.AppUsers;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}