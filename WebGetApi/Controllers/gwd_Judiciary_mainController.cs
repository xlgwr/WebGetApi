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
        public async Task<IHttpActionResult> Getgwd_Judiciary_main(long id)
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
        public async Task<IHttpActionResult> Putgwd_Judiciary_main(long id, gwd_Judiciary_main gwd_Judiciary_main)
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
                        item.htmlID = gwd_Judiciary_main.Tid;
                        item.ClientIP = HttpContext.Current.Request.UserHostAddress;
                        item.UpdateDate = DateTime.Now;
                    }

                    if (gwd_Judiciary_main.gwd_Judiciary_items.Count > 0)
                    {
                        var tmpfirst = gwd_Judiciary_main.gwd_Judiciary_items.First();

                        var tmpExitItem = gwd_Judiciary_itemExists(tmpfirst.tkeyNo, tmpfirst.tLang, tmpfirst.tIndex);
                        if (tmpExitItem)
                        {
                            long tmpHtmlId = 0;
                            foreach (var item in gwd_Judiciary_main.gwd_Judiciary_items)
                            {
                                if (!string.IsNullOrEmpty(item.CourtID))
                                {
                                    var getItem = gwd_Judiciary_itemByNo(item.tkeyNo, item.tLang, item.tIndex);
                                    if (getItem != null)
                                    {
                                        tmpHtmlId = getItem.htmlID;

                                        getItem.CaseNo = item.CaseNo;
                                        getItem.CaseType = item.CaseType;
                                        getItem.Cause = item.Cause;
                                        getItem.ClientIP = item.ClientIP;
                                        getItem.CourtDay = item.CourtDay;
                                        getItem.CourtID = item.CourtID;
                                        getItem.CYear = item.CYear;
                                        getItem.Defendant = item.Defendant;
                                        getItem.Hearing = item.Hearing;
                                        getItem.Judge = item.Judge;
                                        getItem.Nature = item.Nature;
                                        getItem.PlainTiff = item.PlainTiff;
                                        getItem.Remark = item.Remark;
                                        getItem.Representation = item.Representation;
                                        getItem.SerialNo = item.SerialNo;
                                        getItem.tname = item.tname;
                                        getItem.tStatus = item.tStatus;
                                        getItem.ttype = item.ttype;
                                        getItem.UpdateDate = DateTime.Now;
                                    }

                                }
                            }
                            //change main
                            if (tmpHtmlId > 0)
                            {
                                var getMain = gwd_Judiciary_mainByID(tmpHtmlId);

                                if (getMain != null)
                                {

                                    getMain.thtml = gwd_Judiciary_main.thtml;
                                    getMain.tLang = gwd_Judiciary_main.tLang;
                                    getMain.ClientIP = gwd_Judiciary_main.ClientIP;
                                    getMain.Remark = gwd_Judiciary_main.Remark;
                                    getMain.tname = gwd_Judiciary_main.tname;
                                    getMain.tStatus = gwd_Judiciary_main.tStatus;
                                    getMain.ttype = gwd_Judiciary_main.ttype;
                                    getMain.UpdateDate = DateTime.Now;
                                }
                            }
                        }
                        else
                        {
                            db.gwd_Judiciary_main.Add(gwd_Judiciary_main);
                        }



                    }
                    //end if count

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
            //gwd_Judiciary_main gwd_Judiciary_main = await db.gwd_Judiciary_main.FindAsync(id);
            //if (gwd_Judiciary_main == null)
            //{
            //    return NotFound();
            //}

            //db.gwd_Judiciary_main.Remove(gwd_Judiciary_main);
            //await db.SaveChangesAsync();

            //return Ok(gwd_Judiciary_main);
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool gwd_Judiciary_mainExists(long id)
        {
            return db.gwd_Judiciary_main.Count(e => e.Tid == id) > 0;
        }
        private gwd_Judiciary_main gwd_Judiciary_mainByID(long id)
        {
            return db.gwd_Judiciary_main.Where(e => e.Tid == id).FirstOrDefault();
        }


        private bool gwd_Judiciary_itemExists(string id, long lang, long tindex)
        {
            return db.gwd_Judiciary_items.Count(e => e.tkeyNo == id && e.tLang == lang && e.tIndex == tindex) > 0;
        }
        private gwd_Judiciary_items gwd_Judiciary_itemByNo(string id, long lang, long tindex)
        {
            return db.gwd_Judiciary_items.Where(e => e.tkeyNo == id && e.tLang == lang && e.tIndex == tindex).FirstOrDefault();
        }

        private async Task<bool> gwd_Judiciary_mainExistsAsync(long id)
        {
            return await db.gwd_Judiciary_main.CountAsync(e => e.Tid == id) > 0;
        }
    }
}