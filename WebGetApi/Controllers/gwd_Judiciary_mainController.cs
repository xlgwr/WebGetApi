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
using System.Web;
using System.Reflection;
using Common.Logging;

namespace WebGetApi.Controllers
{
    [RoutePrefix("api/GWDJudiciary")]
    public class gwd_Judiciary_mainController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private emmsApiDbContext db = new emmsApiDbContext();

        // GET: api/gwd_Judiciary_main
        public IQueryable<gwd_Judiciary_main> Getgwd_Judiciary_main()
        {
            return db.gwd_Judiciary_main.Take(10);
        }

        // GET: api/gwd_Judiciary_main/5
        [ResponseType(typeof(gwd_Judiciary_main))]
        public async Task<IHttpActionResult> Getgwd_Judiciary_main(string id)
        {
            gwd_Judiciary_main gwd_Judiciary_main = await db.gwd_Judiciary_main.FindAsync(id);
            if (gwd_Judiciary_main == null)
            {
                return NotFound();
            }

            return Ok(gwd_Judiciary_main);
        }
        // PUT: api/gwd_Judiciary_main/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putgwd_Judiciary_main(string id, gwd_Judiciary_main gwd_Judiciary_main)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gwd_Judiciary_main.Tid)
            {
                return BadRequest();
            }

            db.Entry(gwd_Judiciary_main).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gwd_Judiciary_mainExists(id))
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

        // POST: api/gwd_Judiciary_main
        [ResponseType(typeof(gwd_Judiciary_main))]
        public async Task<IHttpActionResult> Postgwd_Judiciary_main(gwd_Judiciary_main gwd_Judiciary_main)
        {
            logger.DebugFormat("Post");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                gwd_Judiciary_main.UpdateDate = DateTime.Now;
                gwd_Judiciary_main.ClientIP = HttpContext.Current.Request.UserHostAddress;

                if (gwd_Judiciary_main.gwd_Judiciary_items != null)
                {
                    foreach (var item in gwd_Judiciary_main.gwd_Judiciary_items)
                    {
                        item.Tid = gwd_Judiciary_main.Tid;
                        item.UpdateDate = DateTime.Now;
                    }

                }
                var tmpexitAs = await gwd_Judiciary_mainExistsAsync(gwd_Judiciary_main.Tid);
                if (tmpexitAs)
                {
                    db.Entry(gwd_Judiciary_main).State = EntityState.Modified;
                    foreach (var item in gwd_Judiciary_main.gwd_Judiciary_items)
                    {
                        if (!string.IsNullOrEmpty(item.CourtID))
                        {
                            if (gwd_Judiciary_itemExists(item.Tid,item.Tindex))
                            {
                                db.Entry(item).State = EntityState.Modified;
                            }
                            else
                            {
                                db.gwd_Judiciary_items.Add(item);
                            }
                            
                        }
                    }

                }
                else
                {
                    db.gwd_Judiciary_main.Add(gwd_Judiciary_main);
                }

                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = gwd_Judiciary_main.Tid }, gwd_Judiciary_main);
        }

        // DELETE: api/gwd_Judiciary_main/5
        [ResponseType(typeof(gwd_Judiciary_main))]
        public async Task<IHttpActionResult> Deletegwd_Judiciary_main(string id)
        {
            gwd_Judiciary_main gwd_Judiciary_main = await db.gwd_Judiciary_main.FindAsync(id);
            if (gwd_Judiciary_main == null)
            {
                return NotFound();
            }

            db.gwd_Judiciary_main.Remove(gwd_Judiciary_main);
            await db.SaveChangesAsync();

            return Ok(gwd_Judiciary_main);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool gwd_Judiciary_mainExists(string id)
        {
            return db.gwd_Judiciary_main.Count(e => e.Tid == id) > 0;
        }
        private bool gwd_Judiciary_itemExists(string id, int tindex)
        {
            return db.gwd_Judiciary_items.Count(e => e.Tid == id && e.Tindex == tindex) > 0;
        }
        private async Task<bool> gwd_Judiciary_mainExistsAsync(string id)
        {
            return await db.gwd_Judiciary_main.CountAsync(e => e.Tid == id) > 0;
        }
    }
}