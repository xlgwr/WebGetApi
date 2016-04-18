using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using EFLibForApi.emms;
using EFLibForApi.emms.models;

namespace WebGetApi.Controllers
{
    public class m_parameterController : ApiController
    {
        private emmsApiDbContext db = new emmsApiDbContext();

        // GET: api/m_parameter
        public IQueryable<m_parameter> Getm_parameter()
        {
            return db.m_parameter;
        }

        // GET: api/m_parameter/5
        [ResponseType(typeof(m_parameter))]
        public async Task<IHttpActionResult> Getm_parameter(string id)
        {
            m_parameter m_parameter = await db.m_parameter.FindAsync(id);
            if (m_parameter == null)
            {
                return NotFound();
            }

            return Ok(m_parameter);
        }

        // PUT: api/m_parameter/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putm_parameter(string id, m_parameter m_parameter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != m_parameter.paramkey)
            {
                return BadRequest();
            }
            m_parameter.UpdateDate = DateTime.Now;

            db.Entry(m_parameter).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!m_parameterExists(id))
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

        // POST: api/m_parameter
        [ResponseType(typeof(m_parameter))]
        public async Task<IHttpActionResult> Postm_parameter(m_parameter m_parameter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try
            {
                m_parameter.UpdateDate = DateTime.Now;

                if (m_parameterExists(m_parameter.paramkey))
                {
                    db.Entry(m_parameter).State = EntityState.Modified;
                }
                else
                {
                    db.m_parameter.Add(m_parameter);
                }
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {

                throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = m_parameter.paramkey }, m_parameter);
        }

        // DELETE: api/m_parameter/5
        [ResponseType(typeof(m_parameter))]
        public async Task<IHttpActionResult> Deletem_parameter(string id)
        {
            m_parameter m_parameter = await db.m_parameter.FindAsync(id);
            if (m_parameter == null)
            {
                return NotFound();
            }

            db.m_parameter.Remove(m_parameter);
            await db.SaveChangesAsync();

            return Ok(m_parameter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool m_parameterExists(string id)
        {
            return db.m_parameter.Count(e => e.paramkey == id) > 0;
        }
    }
}