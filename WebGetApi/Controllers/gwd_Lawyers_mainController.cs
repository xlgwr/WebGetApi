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
    [RoutePrefix("api/GWDLawyers")]
    public class gwd_Lawyers_mainController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private emmsApiDbContext db = new emmsApiDbContext();
        // GET: api/entityMainComm
        public IQueryable<entityCommMain> Get()
        {
            return db.entityCommMain.Take(10);
        }

        // POST: api/entityMainComm
        [ResponseType(typeof(entityCommMain))]
        public async Task<IHttpActionResult> Post(entityCommMain entityMainComm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                entityMainComm.UpdateDate = DateTime.Now;
                entityMainComm.ClientIP = HttpContext.Current.Request.UserHostAddress;

                if (entityMainComm.gwd_Lawyers_items != null)
                {
                    foreach (var item in entityMainComm.gwd_Lawyers_items)
                    {
                        item.htmlID = entityMainComm.Tid;
                        item.ClientIP = HttpContext.Current.Request.UserHostAddress;
                        item.UpdateDate = DateTime.Now;
                    }

                    if (entityMainComm.gwd_Lawyers_items.Count > 0)
                    {
                        var tmpfirst = entityMainComm.gwd_Lawyers_items.First();

                        var tmpExitItem = gwd_Lawyers_itemsExists(tmpfirst.tkeyNo, tmpfirst.tLang, tmpfirst.tIndex);
                        if (tmpExitItem)
                        {
                            long tmpHtmlId = 0;
                            foreach (var item in entityMainComm.gwd_Lawyers_items)
                            {
                                if (!string.IsNullOrEmpty(item.LawyerName) || !string.IsNullOrEmpty(item.ChineseName))
                                {
                                    var getItem = gwd_Lawyers_itemsByNo(item.tkeyNo, item.tLang, item.tIndex);
                                    if (getItem != null)
                                    {
                                        tmpHtmlId = getItem.htmlID;

                                        getItem.ApproveCountry = item.ApproveCountry;
                                        getItem.ApproveDate = item.ApproveDate;
                                        getItem.BeforeName = item.BeforeName;
                                        getItem.ClientIP = item.ClientIP;
                                        getItem.ChineseAddress = item.ChineseAddress;
                                        getItem.ChineseCompany = item.ChineseCompany;
                                        getItem.ChineseName = item.ChineseName;
                                        getItem.CompanyAddress = item.CompanyAddress;
                                        getItem.CompanyEmail = item.CompanyEmail;
                                        getItem.CompanyFax = item.CompanyFax;
                                        getItem.Companytel = item.Companytel;
                                        getItem.Dxnumber = item.Dxnumber;
                                        getItem.Remark = item.Remark;
                                        getItem.LawyerCompany = item.LawyerCompany;
                                        getItem.LawyerEmail = item.LawyerEmail;
                                        getItem.LawyerName = item.LawyerName;
                                        getItem.OtherDate = item.OtherDate;
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
                                var getMain = entityMainCommByID(tmpHtmlId);

                                if (getMain != null)
                                {

                                    getMain.thtml = entityMainComm.thtml;
                                    getMain.tLang = entityMainComm.tLang;
                                    getMain.ClientIP = entityMainComm.ClientIP;
                                    getMain.Remark = entityMainComm.Remark;
                                    getMain.tname = entityMainComm.tname;
                                    getMain.tStatus = entityMainComm.tStatus;
                                    getMain.ttype = entityMainComm.ttype;
                                    getMain.UpdateDate = DateTime.Now;
                                }
                            }
                        }
                        else
                        {
                            db.entityCommMain.Add(entityMainComm);
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
            //return CreatedAtRoute("DefaultApi", new { id = entityMainComm.Tid }, entityMainComm);

        }
        private bool gwtMainExistsAsync(long id)
        {
            return db.entityCommMain.Count(e => e.Tid == id) > 0;
        }
        private entityCommMain entityMainCommByID(long id)
        {
            return db.entityCommMain.Where(e => e.Tid == id).FirstOrDefault();
        }

        private bool gwd_Lawyers_itemsExists(string id, long lang, long tindex)
        {
            return db.gwd_Lawyers_items.Count(e => e.tkeyNo == id && e.tLang == lang && e.tIndex == tindex) > 0;
        }
        private gwd_Lawyers_items gwd_Lawyers_itemsByNo(string id, long lang, long tindex)
        {
            return db.gwd_Lawyers_items.Where(e => e.tkeyNo == id && e.tLang == lang && e.tIndex == tindex).FirstOrDefault();
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
