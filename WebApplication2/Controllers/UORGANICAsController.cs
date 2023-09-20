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
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class UORGANICAsController : ApiController
    {
        private HVALLESEntities db = new HVALLESEntities();

        // GET: api/UORGANICAs
        public IQueryable<UORGANICA> GetUORGANICAs()
        {
			db.Configuration.ProxyCreationEnabled = false;
			db.Configuration.LazyLoadingEnabled = true;
			return db.UORGANICAs;
        }

        // GET: api/UORGANICAs/5
        [ResponseType(typeof(UORGANICA))]
        public IHttpActionResult GetUORGANICA(int id)
        {
            UORGANICA uORGANICA = db.UORGANICAs.Find(id);
            if (uORGANICA == null)
            {
                return NotFound();
            }

            return Ok(uORGANICA);
        }

        // PUT: api/UORGANICAs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUORGANICA(int id, UORGANICA uORGANICA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uORGANICA.UOR_ID)
            {
                return BadRequest();
            }

            db.Entry(uORGANICA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UORGANICAExists(id))
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

        // POST: api/UORGANICAs
        [ResponseType(typeof(UORGANICA))]
        public IHttpActionResult PostUORGANICA(UORGANICA uORGANICA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UORGANICAs.Add(uORGANICA);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = uORGANICA.UOR_ID }, uORGANICA);
        }

        // DELETE: api/UORGANICAs/5
        [ResponseType(typeof(UORGANICA))]
        public IHttpActionResult DeleteUORGANICA(int id)
        {
            UORGANICA uORGANICA = db.UORGANICAs.Find(id);
            if (uORGANICA == null)
            {
                return NotFound();
            }

            db.UORGANICAs.Remove(uORGANICA);
            db.SaveChanges();

            return Ok(uORGANICA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UORGANICAExists(int id)
        {
            return db.UORGANICAs.Count(e => e.UOR_ID == id) > 0;
        }
    }
}