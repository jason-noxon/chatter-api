using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Chatter.Api.Models;

namespace Chatter.Api.Areas.v1.Controllers
{

    public class ChitController : ApiController
    {
        private List<Chit> chits = new List<Chit> {
        new Chit { Id = 1, UserName = "Gollum", Message="Has anyone seen my ring?" },
        new Chit { Id = 2, UserName = "Bilbo", Message="I found this awesome ring!" }
    };

        // GET: api/Chit
        public List<Chit> Get()
        {
            return chits;
        }

        // GET: api/Chit/5
        public Chit Get(int id)
        {
            return chits.Where( c => c.Id == id).FirstOrDefault();
        }

        // POST: api/Chit
        public void Post([FromBody]Chit chit)
        {
            chits.Add(chit);
        }

        // PUT: api/Chit/5
        public void Put(int id, [FromBody]Chit chit)
        {
            var itemToEdit = chits.FirstOrDefault(c => c.Id == id);
            chits.Remove(itemToEdit);
            chits.Add(chit);
        }

        // DELETE: api/Chit/5
        public void Delete(int id)
        {
            var itemToRemove = chits.Where(c => c.Id == id).FirstOrDefault();
            chits.Remove(itemToRemove);
        }
    }
}
