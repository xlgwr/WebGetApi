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
    [RoutePrefix("api/GWDlegalref")]
    public class gwd_legalref_mainController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private emmsApiDbContext db = new emmsApiDbContext();

        // GET: api/gwd_legalref_main
        public IQueryable<gwd_legalref_main> Get()
        {
            return db.gwd_legalref_main.Take(10);
        }

        // GET: api/gwd_legalref_main/5
        [ResponseType(typeof(gwd_legalref_main))]
        public async Task<IHttpActionResult> Get(string id, string id2, string id3, string id4, string id5)
        {
            ///FACC2/2015/29/01/2016
            var tid = id.Trim() + "/" + id2.Trim();
            var tDate = id3.Trim() + "/" + id4.Trim() + "/" + id5.Trim();

            gwd_legalref_main gwd_legalref_main = await db.gwd_legalref_main.FindAsync(new object[] { tid, tDate });
            if (gwd_legalref_main == null)
            {
                return NotFound();
            }

            return Ok(gwd_legalref_main);
        }
        // GET: api/GetWebDatas/GetWebDatasMaxTDis
        [ResponseType(typeof(long))]
        [Route("GetWebDatasMaxTDis")]
        public async Task<IHttpActionResult> GetWebDatasMaxAsync()
        {
            long getWebDatas = 1;
            try
            {
                getWebDatas = await db.gwd_legalref_main.MaxAsync(m => m.TGetDis);
            }
            catch (Exception)
            {
                getWebDatas = 1;
            }

            return Ok(getWebDatas);
        }
        // POST: api/gwd_legalref_main
        [ResponseType(typeof(gwd_legalref_main))]
        public async Task<IHttpActionResult> Post(gwd_legalref_main gwd_legalref_main)
        {
            logger.DebugFormat("Post");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                gwd_legalref_main.UpdateDate = DateTime.Now;
                gwd_legalref_main.Remark = HttpContext.Current.Request.UserHostAddress;

                if (gwd_legalref_main.gwd_legalref_items != null)
                {
                    foreach (var item in gwd_legalref_main.gwd_legalref_items)
                    {
                        item.Tid = gwd_legalref_main.Tid;
                        item.UpdateDate = DateTime.Now;
                    }

                }
                var tmpexitAs = await gwtMainExistsAsync(gwd_legalref_main.TDis);
                if (tmpexitAs)
                {
                    db.Entry(gwd_legalref_main).State = EntityState.Modified;
                    foreach (var item in gwd_legalref_main.gwd_legalref_items)
                    {
                        if (!string.IsNullOrEmpty(item.thtml))
                        {
                            if (gwdItemExists(item.Tid, item.TIndex))
                            {
                                db.Entry(item).State = EntityState.Modified;
                            }
                            else
                            {
                                db.gwd_legalref_items.Add(item);
                            }

                        }
                    }

                }
                else
                {
                    db.gwd_legalref_main.Add(gwd_legalref_main);
                }

                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = gwd_legalref_main.Tid }, gwd_legalref_main);

        }

        // PUT: api/gwd_legalref_main/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/gwd_legalref_main/5
        public void Delete(int id)
        {
        }
        private async Task<bool> gwtMainExistsAsync(long id)
        {
            return await db.gwd_legalref_main.CountAsync(e => e.TDis == id) > 0;
        }
        private bool gwdItemExists(string id, int tindex)
        {
            return db.gwd_legalref_items.Count(e => e.Tid == id && e.TIndex == tindex) > 0;
        }
    }
}
