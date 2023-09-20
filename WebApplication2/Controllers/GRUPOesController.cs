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
    public class GRUPOesController : ApiController
    {
        private HVALLESEntities db = new HVALLESEntities();

        // GET: api/GRUPOes
        public IQueryable<GRUPO> GetGRUPOes()
        {
			db.Configuration.ProxyCreationEnabled = false;
			db.Configuration.LazyLoadingEnabled = true;
			return db.GRUPOes;
        }

        // GET: api/GRUPOes/5
        [ResponseType(typeof(GRUPO))]
        public IHttpActionResult GetGRUPO(int id)
        {
            GRUPO gRUPO = db.GRUPOes.Find(id);
            if (gRUPO == null)
            {
                return NotFound();
            }

            return Ok(gRUPO);
        }

        // PUT: api/GRUPOes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGRUPO(int id, GRUPO gRUPO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gRUPO.GRU_ID)
            {
                return BadRequest();
            }

            db.Entry(gRUPO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GRUPOExists(id))
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

        // POST: api/GRUPOes
        [ResponseType(typeof(GRUPO))]
        public IHttpActionResult PostGRUPO(GRUPO gRUPO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GRUPOes.Add(gRUPO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gRUPO.GRU_ID }, gRUPO);
        }

        // DELETE: api/GRUPOes/5
        [ResponseType(typeof(GRUPO))]
        public IHttpActionResult DeleteGRUPO(int id)
        {
            GRUPO gRUPO = db.GRUPOes.Find(id);
            if (gRUPO == null)
            {
                return NotFound();
            }

            db.GRUPOes.Remove(gRUPO);
            db.SaveChanges();

            return Ok(gRUPO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GRUPOExists(int id)
        {
            return db.GRUPOes.Count(e => e.GRU_ID == id) > 0;
        }
    }
}