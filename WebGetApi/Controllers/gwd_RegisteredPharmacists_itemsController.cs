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
    /// Registered Pharmacists
    /// </summary>
    [RoutePrefix("api/GWDRegisteredPharmacists")]
    public class gwd_RegisteredPharmacists_itemsController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private emmsApiDbContext db = new emmsApiDbContext();
        // GET: api/entityCommMain
        public IQueryable<entityCommMain> Get()
        {
            return db.entityCommMain.Take(10);
        }

        // POST: api/entityCommMain
        [ResponseType(typeof(entityCommMain))]
        public async Task<IHttpActionResult> Post(entityCommMain entityCommMain)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                entityCommMain.UpdateDate = DateTime.Now;
                entityCommMain.ClientIP = HttpContext.Current.Request.UserHostAddress;

                if (entityCommMain.gwd_RegisteredPharmacists_items != null)
                {
                    foreach (var item in entityCommMain.gwd_RegisteredPharmacists_items)
                    {
                        item.htmlID = entityCommMain.Tid;
                        item.ClientIP = HttpContext.Current.Request.UserHostAddress;
                        item.UpdateDate = DateTime.Now;
                    }

                    if (entityCommMain.gwd_RegisteredPharmacists_items.Count > 0)
                    {
                        var tmpfirst = entityCommMain.gwd_RegisteredPharmacists_items.First();

                        var tmpExitItem = gwd_RegisteredPharmacists_itemsExists(tmpfirst.tkeyNo, tmpfirst.tLang, tmpfirst.tIndex);
                        if (tmpExitItem)
                        {
                            long tmpHtmlId = 0;
                            foreach (var item in entityCommMain.gwd_RegisteredPharmacists_items)
                            {
                                if (!string.IsNullOrEmpty(item.RegNo) || !string.IsNullOrEmpty(item.RegName))
                                {
                                    var getItem = gwd_RegisteredPharmacists_itemsByNo(item.tkeyNo, item.tLang, item.tIndex);
                                    if (getItem != null)
                                    {
                                        tmpHtmlId = getItem.htmlID;

                                        getItem.tIndex = item.tIndex;
                                        getItem.RegName = item.RegName;
                                        getItem.RegNameZH = item.RegNameZH;
                                        getItem.Qualifications = item.Qualifications;
                                        getItem.RegDate = item.RegDate;

                                        getItem.ClientIP = item.ClientIP;
                                        getItem.Remark = item.Remark;

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
                                var getMain = entityCommMainByID(tmpHtmlId);

                                if (getMain != null)
                                {

                                    getMain.thtml = entityCommMain.thtml;
                                    getMain.tLang = entityCommMain.tLang;
                                    getMain.ClientIP = entityCommMain.ClientIP;
                                    getMain.Remark = entityCommMain.Remark;
                                    getMain.tname = entityCommMain.tname;
                                    getMain.tStatus = entityCommMain.tStatus;
                                    getMain.ttype = entityCommMain.ttype;
                                    getMain.UpdateDate = DateTime.Now;
                                }
                            }
                        }
                        else
                        {
                            db.entityCommMain.Add(entityCommMain);
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
            //return CreatedAtRoute("DefaultApi", new { id = entityCommMain.Tid }, entityCommMain);

        }
        private bool gwtMainExistsAsync(long id)
        {
            return db.entityCommMain.Count(e => e.Tid == id) > 0;
        }
        private entityCommMain entityCommMainByID(long id)
        {
            return db.entityCommMain.Where(e => e.Tid == id).FirstOrDefault();
        }

        private bool gwd_RegisteredPharmacists_itemsExists(string id, long lang, long tindex)
        {
            return db.gwd_RegisteredPharmacists_items.Count(e => e.tkeyNo == id && e.tLang == lang) > 0;
        }
        private gwd_RegisteredPharmacists_items gwd_RegisteredPharmacists_itemsByNo(string id, long lang, long tindex)
        {
            return db.gwd_RegisteredPharmacists_items.Where(e => e.tkeyNo == id && e.tLang == lang).FirstOrDefault();
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
