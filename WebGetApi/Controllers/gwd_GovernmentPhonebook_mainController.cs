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
    /// <summary>
    /// 香港特别行政区政府及有关机构电话薄
    /// </summary>
    [RoutePrefix("api/GWDGovernmentPhonebook")]
    public class gwd_GovernmentPhonebook_mainController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private emmsApiDbContext db = new emmsApiDbContext();
        // GET: api/gwd_GovernmentPhonebook_main
        public IQueryable<gwd_GovernmentPhonebook_main> Get()
        {
            return db.gwd_GovernmentPhonebook_main.Take(10);
        }

        // POST: api/gwd_GovernmentPhonebook_main
        [ResponseType(typeof(gwd_GovernmentPhonebook_main))]
        public async Task<IHttpActionResult> Post(gwd_GovernmentPhonebook_main gwd_GovernmentPhonebook_main)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                gwd_GovernmentPhonebook_main.UpdateDate = DateTime.Now;
                gwd_GovernmentPhonebook_main.ClientIP = HttpContext.Current.Request.UserHostAddress;

                if (gwd_GovernmentPhonebook_main.gwd_GovernmentPhonebook_items != null)
                {
                    foreach (var item in gwd_GovernmentPhonebook_main.gwd_GovernmentPhonebook_items)
                    {
                        item.htmlID = gwd_GovernmentPhonebook_main.Tid;
                        item.ClientIP = HttpContext.Current.Request.UserHostAddress;
                        item.UpdateDate = DateTime.Now;
                    }

                    if (gwd_GovernmentPhonebook_main.gwd_GovernmentPhonebook_items.Count > 0)
                    {
                        var tmpfirst = gwd_GovernmentPhonebook_main.gwd_GovernmentPhonebook_items.First();

                        var tmpExitItem = gwd_GovernmentPhonebook_itemsExists(tmpfirst.tkeyNo, tmpfirst.tLang, tmpfirst.tIndex);
                        if (tmpExitItem)
                        {
                            long tmpHtmlId = 0;
                            foreach (var item in gwd_GovernmentPhonebook_main.gwd_GovernmentPhonebook_items)
                            {
                                if (!string.IsNullOrEmpty(item.FullName) || !string.IsNullOrEmpty(item.OfficePhone))
                                {
                                    var getItem = gwd_GovernmentPhonebook_itemsByNo(item.tkeyNo, item.tLang, item.tIndex);
                                    if (getItem != null)
                                    {
                                        tmpHtmlId = getItem.htmlID;

                                        getItem.FullName = item.FullName;
                                        getItem.OfficePhone = item.OfficePhone;
                                        getItem.ClientIP = item.ClientIP;
                                        getItem.Email = item.Email;
                                        getItem.Remark = item.Remark;
                                        getItem.Title = item.Title;

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
                                var getMain = gwd_GovernmentPhonebook_mainByID(tmpHtmlId);

                                if (getMain != null)
                                {

                                    getMain.thtml = gwd_GovernmentPhonebook_main.thtml;
                                    getMain.tLang = gwd_GovernmentPhonebook_main.tLang;
                                    getMain.ClientIP = gwd_GovernmentPhonebook_main.ClientIP;
                                    getMain.Remark = gwd_GovernmentPhonebook_main.Remark;
                                    getMain.tname = gwd_GovernmentPhonebook_main.tname;
                                    getMain.tStatus = gwd_GovernmentPhonebook_main.tStatus;
                                    getMain.ttype = gwd_GovernmentPhonebook_main.ttype;
                                    getMain.UpdateDate = DateTime.Now;
                                }
                            }
                        }
                        else
                        {
                            db.gwd_GovernmentPhonebook_main.Add(gwd_GovernmentPhonebook_main);
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
            //return CreatedAtRoute("DefaultApi", new { id = gwd_GovernmentPhonebook_main.Tid }, gwd_GovernmentPhonebook_main);

        }
        private bool gwtMainExistsAsync(long id)
        {
            return db.gwd_GovernmentPhonebook_main.Count(e => e.Tid == id) > 0;
        }
        private gwd_GovernmentPhonebook_main gwd_GovernmentPhonebook_mainByID(long id)
        {
            return db.gwd_GovernmentPhonebook_main.Where(e => e.Tid == id).FirstOrDefault();
        }

        private bool gwd_GovernmentPhonebook_itemsExists(string id, long lang, long tindex)
        {
            return db.gwd_GovernmentPhonebook_items.Count(e => e.tkeyNo == id && e.tLang == lang && e.tIndex == tindex) > 0;
        }
        private gwd_GovernmentPhonebook_items gwd_GovernmentPhonebook_itemsByNo(string id, long lang, long tindex)
        {
            return db.gwd_GovernmentPhonebook_items.Where(e => e.tkeyNo == id && e.tLang == lang && e.tIndex == tindex).FirstOrDefault();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
