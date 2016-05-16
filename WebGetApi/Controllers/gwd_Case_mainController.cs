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
    [RoutePrefix("api/GWDCase")]
    public class gwd_Case_mainController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private emmsApiDbContext db = new emmsApiDbContext();

        // GET: api/gwd_Case_main
        public IQueryable<gwd_Case_main> Getgwd_Case_main()
        {
            return db.gwd_Case_main.Take(10);
        }

        // GET: api/gwd_Case_main/5
        [ResponseType(typeof(gwd_Case_main))]
        public async Task<IHttpActionResult> Getgwd_Case_main(long id)
        {
            gwd_Case_main gwd_Case_main = await db.gwd_Case_main.FindAsync(id);
            if (gwd_Case_main == null)
            {
                return NotFound();
            }

            return Ok(gwd_Case_main);
        }
        // POST: api/gwd_Case_main
        [ResponseType(typeof(gwd_Case_main))]
        public async Task<IHttpActionResult> Postgwd_Case_main(gwd_Case_main gwd_Case_main)
        {
            logger.DebugFormat("Post");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                gwd_Case_main.UpdateDate = DateTime.Now;
                gwd_Case_main.ClientIP = HttpContext.Current.Request.UserHostAddress;

                if (gwd_Case_main.gwd_Case_items != null)
                {
                    foreach (var item in gwd_Case_main.gwd_Case_items)
                    {
                        item.htmlID = gwd_Case_main.Tid;
                        item.ClientIP = HttpContext.Current.Request.UserHostAddress;
                        item.UpdateDate = DateTime.Now;
                    }

                    if (gwd_Case_main.gwd_Case_items.Count > 0)
                    {
                        var tmpfirst = gwd_Case_main.gwd_Case_items.First();

                        var tmpExitItem = gwd_Case_itemExists(tmpfirst.tkeyNo, tmpfirst.tLang, tmpfirst.tIndex);
                        if (tmpExitItem)
                        {
                            long tmpHtmlId = 0;
                            foreach (var item in gwd_Case_main.gwd_Case_items)
                            {
                                if (!string.IsNullOrEmpty(item.CourtID))
                                {
                                    var getItem = gwd_Case_itemByNo(item.tkeyNo, item.tLang, item.tIndex);
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

                                        getItem.Actiondate = item.Actiondate;
                                        getItem.Currency = item.Currency;
                                        getItem.Amount = item.Amount;
                                        getItem.CheckField = item.CheckField;



                                    }

                                }
                            }
                            //change main
                            if (tmpHtmlId > 0)
                            {
                                var getMain = gwd_Case_mainByID(tmpHtmlId);

                                if (getMain != null)
                                {

                                    getMain.thtml = gwd_Case_main.thtml;
                                    getMain.tLang = gwd_Case_main.tLang;
                                    getMain.ClientIP = gwd_Case_main.ClientIP;
                                    getMain.Remark = gwd_Case_main.Remark;
                                    getMain.tname = gwd_Case_main.tname;
                                    getMain.tStatus = gwd_Case_main.tStatus;
                                    getMain.ttype = gwd_Case_main.ttype;
                                    getMain.UpdateDate = DateTime.Now;
                                }
                            }
                        }
                        else
                        {
                            db.gwd_Case_main.Add(gwd_Case_main);
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
            return Ok();
            //return CreatedAtRoute("DefaultApi", new { id = gwd_Case_main.Tid }, gwd_Case_main);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool gwd_Case_mainExists(long id)
        {
            return db.gwd_Case_main.Count(e => e.Tid == id) > 0;
        }
        private gwd_Case_main gwd_Case_mainByID(long id)
        {
            return db.gwd_Case_main.Where(e => e.Tid == id).FirstOrDefault();
        }


        private bool gwd_Case_itemExists(string id, long lang, long tindex)
        {
            return db.gwd_Case_items.Count(e => e.tkeyNo == id && e.tLang == lang && e.tIndex == tindex) > 0;
        }
        private gwd_Case_items gwd_Case_itemByNo(string id, long lang, long tindex)
        {
            return db.gwd_Case_items.Where(e => e.tkeyNo == id && e.tLang == lang && e.tIndex == tindex).FirstOrDefault();
        }

        private async Task<bool> gwd_Case_mainExistsAsync(long id)
        {
            return await db.gwd_Case_main.CountAsync(e => e.Tid == id) > 0;
        }
    }
}