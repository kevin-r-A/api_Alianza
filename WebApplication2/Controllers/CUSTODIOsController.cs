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
    public class CUSTODIOsController : ApiController
    {
        private HVALLESEntities db = new HVALLESEntities();

        // GET: api/CUSTODIOs
        public IQueryable<CUSTODIO> GetCUSTODIOs()
        {
			db.Configuration.ProxyCreationEnabled = false;
			db.Configuration.LazyLoadingEnabled = true;
			return db.CUSTODIOs;
        }

        // GET: api/CUSTODIOs/5
        [ResponseType(typeof(CUSTODIO))]
        public IHttpActionResult GetCUSTODIO(int id)
        {
            CUSTODIO cUSTODIO = db.CUSTODIOs.Find(id);
            if (cUSTODIO == null)
            {
                return NotFound();
            }

            return Ok(cUSTODIO);
        }

        // PUT: api/CUSTODIOs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCUSTODIO(int id, CUSTODIO cUSTODIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cUSTODIO.CUS_ID)
            {
                return BadRequest();
            }

            db.Entry(cUSTODIO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CUSTODIOExists(id))
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

        // POST: api/CUSTODIOs
        [ResponseType(typeof(CUSTODIO))]
        public IHttpActionResult PostCUSTODIO(CUSTODIO cUSTODIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CUSTODIOs.Add(cUSTODIO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cUSTODIO.CUS_ID }, cUSTODIO);
        }

        // DELETE: api/CUSTODIOs/5
        [ResponseType(typeof(CUSTODIO))]
        public IHttpActionResult DeleteCUSTODIO(int id)
        {
            CUSTODIO cUSTODIO = db.CUSTODIOs.Find(id);
            if (cUSTODIO == null)
            {
                return NotFound();
            }

            db.CUSTODIOs.Remove(cUSTODIO);
            db.SaveChanges();

            return Ok(cUSTODIO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CUSTODIOExists(int id)
        {
            return db.CUSTODIOs.Count(e => e.CUS_ID == id) > 0;
        }
    }
}