using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Chatter.Api.Models;
using Chatter.Api.DAL;

namespace Chatter.Api.Areas.v1.Controllers
{

    public class ChitController : ApiController
    {
        private ChatterContext db = new ChatterContext();

        // GET: api/Chit
        public List<Chit> Get()
        {
            return db.Chits.ToList();
        }

        // GET: api/Chit/5
        public Chit Get(int id)
        {
            return db.Chits.Where( c => c.Id == id).FirstOrDefault();
        }

        // POST: api/Chit
        public void Post([FromBody]Chit chit)
        {
            db.Chits.Add(chit);

            db.SaveChanges();
        }

        // PUT: api/Chit/5
        public void Put([FromBody]Chit chit)
        {
            var itemToEdit = db.Chits.FirstOrDefault(c => c.Id == chit.Id);
            db.Chits.Remove(itemToEdit);

            db.SaveChanges();

            db.Chits.Add(chit);
            db.SaveChanges();
        }

        // DELETE: api/Chit/5
        public void Delete(int id)
        {
            var itemToRemove = db.Chits.Where(c => c.Id == id).FirstOrDefault();
            db.Chits.Remove(itemToRemove);

            db.SaveChanges();
        }
    }
}
