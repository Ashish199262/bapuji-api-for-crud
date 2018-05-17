using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BapujiWebAPI.Models;

namespace BapujiWebAPI.Controllers
{
    public class PERSON_MASTER_TBLController : ApiController
    {
        private bapujidbEntities db = new bapujidbEntities();

        // GET: api/PERSON_MASTER_TBL
        [Route("api/GetPerson")]
        public IQueryable<PERSON_MASTER_TBL> GetPERSON_MASTER_TBL()
        {
            return db.PERSON_MASTER_TBL;
        }

        // GET: api/PERSON_MASTER_TBL/5
        [ResponseType(typeof(PERSON_MASTER_TBL))]
        public IHttpActionResult GetPERSON_MASTER_TBL(long id)
        {
            PERSON_MASTER_TBL pERSON_MASTER_TBL = db.PERSON_MASTER_TBL.Find(id);
            if (pERSON_MASTER_TBL == null)
            {
                return NotFound();
            }

            return Ok(pERSON_MASTER_TBL);
        }

        // PUT: api/PERSON_MASTER_TBL/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPERSON_MASTER_TBL(long id, PERSON_MASTER_TBL pERSON_MASTER_TBL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pERSON_MASTER_TBL.PERSONID)
            {
                return BadRequest();
            }

            db.Entry(pERSON_MASTER_TBL).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PERSON_MASTER_TBLExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PERSON_MASTER_TBL
     
        [ResponseType(typeof(PERSON_MASTER_TBL))]
        public IHttpActionResult PostPERSON_MASTER_TBL(PERSON_MASTER_TBL pERSON_MASTER_TBL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PERSON_MASTER_TBL.Add(pERSON_MASTER_TBL);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pERSON_MASTER_TBL.PERSONID }, pERSON_MASTER_TBL);
        }

        // DELETE: api/PERSON_MASTER_TBL/5
       
        [ResponseType(typeof(PERSON_MASTER_TBL))]
        
        public IHttpActionResult DeletePERSON_MASTER_TBL(long id)
        {
            PERSON_MASTER_TBL pERSON_MASTER_TBL = db.PERSON_MASTER_TBL.Find(id);
            if (pERSON_MASTER_TBL == null)
            {
                return NotFound();
            }

            db.PERSON_MASTER_TBL.Remove(pERSON_MASTER_TBL);
            db.SaveChanges();

            return Ok(pERSON_MASTER_TBL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PERSON_MASTER_TBLExists(long id)
        {
            return db.PERSON_MASTER_TBL.Count(e => e.PERSONID == id) > 0;
        }
    }
}