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
    public class REPORTEsController : ApiController
    {
        private HVALLESEntities db = new HVALLESEntities();

        // GET: api/REPORTEs
        public IQueryable<REPORTE> GetREPORTEs()
        {
            return db.REPORTEs;
        }

        // GET: api/REPORTEs/5
        [ResponseType(typeof(REPORTE))]
        public IHttpActionResult GetREPORTE(int id)
        {
            REPORTE rEPORTE = db.REPORTEs.Find(id);
            if (rEPORTE == null)
            {
                return NotFound();
            }

            return Ok(rEPORTE);
        }

        // PUT: api/REPORTEs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutREPORTE(int id, REPORTE rEPORTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rEPORTE.REP_CODIGO)
            {
                return BadRequest();
            }

            db.Entry(rEPORTE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!REPORTEExists(id))
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

        // POST: api/REPORTEs
        [ResponseType(typeof(REPORTE))]
        public IHttpActionResult PostREPORTE(List<REPORTE> rEPORTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			db.Database.ExecuteSqlCommand("DELETE FROM REPORTE");
            db.REPORTEs.AddRange(rEPORTE);
            db.SaveChanges();

			return Ok(Json("Ok"));
            //return CreatedAtRoute("DefaultApi", new { id = rEPORTE.REP_CODIGO }, rEPORTE);
        }

        // DELETE: api/REPORTEs/5
        [ResponseType(typeof(REPORTE))]
        public IHttpActionResult DeleteREPORTE(int id)
        {
            REPORTE rEPORTE = db.REPORTEs.Find(id);
            if (rEPORTE == null)
            {
                return NotFound();
            }

            db.REPORTEs.Remove(rEPORTE);
            db.SaveChanges();

            return Ok(rEPORTE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool REPORTEExists(int id)
        {
            return db.REPORTEs.Count(e => e.REP_CODIGO == id) > 0;
        }
    }
}