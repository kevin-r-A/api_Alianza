using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication2;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ACTIVOesController : ApiController
    {
		private HVALLESEntities db = new HVALLESEntities();

        // GET: api/ACTIVOes
        public IQueryable<ACTIVO> GetACTIVOes()
        {
			db.Configuration.ProxyCreationEnabled = false;
			db.Configuration.LazyLoadingEnabled = true;
			return db.ACTIVOes;
        }

		// GET: api/ACTIVOes
		[ResponseType(typeof(List<ACTIVO>))]
		public IHttpActionResult GetACTIVOs(int PPC_ID)
		{
			db.Configuration.ProxyCreationEnabled = false;
			db.Configuration.LazyLoadingEnabled = true;
			List<ACTIVO> aCTIVOs = db.ACTIVOes.Where(x=>x.ACT_PPC==PPC_ID).ToList();
			return Ok(aCTIVOs);
		}

		// GET: api/ACTIVOes/5
		[ResponseType(typeof(ACTIVO))]
        public IHttpActionResult GetACTIVO(int id)
        {
			db.Configuration.ProxyCreationEnabled = false;
			db.Configuration.LazyLoadingEnabled = true;
            ACTIVO aCTIVO = db.ACTIVOes.Find(id);
            if (aCTIVO == null)
            {
                return NotFound();
            }

            return Ok(aCTIVO);
        }

        // PUT: api/ACTIVOes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutACTIVO(int id, ACTIVO aCTIVO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aCTIVO.ACT_ID)
            {
                return BadRequest();
            }

            db.Entry(aCTIVO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ACTIVOExists(id))
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

        // POST: api/ACTIVOes
        [ResponseType(typeof(ACTIVO))]
        public IHttpActionResult PostACTIVO(ACTIVO aCTIVO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ACTIVOes.Add(aCTIVO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ACTIVOExists(aCTIVO.ACT_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aCTIVO.ACT_ID }, aCTIVO);
        }

        // DELETE: api/ACTIVOes/5
        [ResponseType(typeof(ACTIVO))]
        public IHttpActionResult DeleteACTIVO(int id)
        {
            ACTIVO aCTIVO = db.ACTIVOes.Find(id);
            if (aCTIVO == null)
            {
                return NotFound();
            }

            db.ACTIVOes.Remove(aCTIVO);
            db.SaveChanges();

            return Ok(aCTIVO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ACTIVOExists(int id)
        {
            return db.ACTIVOes.Count(e => e.ACT_ID == id) > 0;
        }
    }
}