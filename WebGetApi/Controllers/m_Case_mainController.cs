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
    public class m_Case_mainController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private emmsApiDbContext db = new emmsApiDbContext();

        // GET: api/m_Case_main
        public IQueryable<m_Case_main> Getm_Case_main()
        {
            return db.m_Case_main.Take(10);
        }

        // GET: api/m_Case_main/5
        [ResponseType(typeof(m_Case_main))]
        public async Task<IHttpActionResult> Getm_Case_main(long id)
        {
            m_Case_main m_Case_main = await db.m_Case_main.FindAsync(id);
            if (m_Case_main == null)
            {
                return NotFound();
            }

            return Ok(m_Case_main);
        }
        // POST: api/m_Case_main
        [ResponseType(typeof(m_Case_main))]
        public async Task<IHttpActionResult> Postm_Case_main(m_Case_main m_Case_main)
        {
            logger.DebugFormat("Post");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                m_Case_main.updtime = DateTime.Now;
                m_Case_main.ClientIP = HttpContext.Current.Request.UserHostAddress;

                if (m_Case_main.m_Case_items != null)
                {
                    foreach (var item in m_Case_main.m_Case_items)
                    {
                        item.htmlID = m_Case_main.Tid;
                        item.ClientIP = HttpContext.Current.Request.UserHostAddress;
                        item.updtime = DateTime.Now;
                    }

                    if (m_Case_main.m_Case_items.Count > 0)
                    {
                        var tmpfirst = m_Case_main.m_Case_items.First();

                        var tmpExitItem = m_Case_itemExists(tmpfirst.tkeyNo, tmpfirst.tLang, tmpfirst.tIndex);
                        if (tmpExitItem)
                        {
                            long tmpHtmlId = 0;
                            foreach (var item in m_Case_main.m_Case_items)
                            {
                                if (!string.IsNullOrEmpty(item.CourtID))
                                {
                                    var getItem = m_Case_itemByNo(item.tkeyNo, item.tLang, item.tIndex);
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
                                        getItem.Hearing = item.Hearing;
                                        getItem.Judge = item.Judge;
                                        getItem.Nature = item.Nature;
                                        getItem.Parties = item.Parties;

                                        getItem.Defendant = item.Defendant;
                                        getItem.PlainTiff = item.PlainTiff;

                                        getItem.Remark = item.Remark;
                                        getItem.Representation = item.Representation;
                                        getItem.SerialNo = item.SerialNo;
                                        getItem.tname = item.tname;
                                        getItem.tStatus = item.tStatus;
                                        getItem.ttype = item.ttype;
                                        getItem.updtime = DateTime.Now;

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
                                var getMain = m_Case_mainByID(tmpHtmlId);

                                if (getMain != null)
                                {

                                    getMain.thtml = m_Case_main.thtml;
                                    getMain.tLang = m_Case_main.tLang;
                                    getMain.ClientIP = m_Case_main.ClientIP;
                                    getMain.Remark = m_Case_main.Remark;
                                    getMain.tname = m_Case_main.tname;
                                    getMain.tStatus = m_Case_main.tStatus;
                                    getMain.ttype = m_Case_main.ttype;
                                    getMain.updtime = DateTime.Now;
                                }
                            }
                        }
                        else
                        {
                            db.m_Case_main.Add(m_Case_main);
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
            //return CreatedAtRoute("DefaultApi", new { id = m_Case_main.Tid }, m_Case_main);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool m_Case_mainExists(long id)
        {
            return db.m_Case_main.Count(e => e.Tid == id) > 0;
        }
        private m_Case_main m_Case_mainByID(long id)
        {
            return db.m_Case_main.Where(e => e.Tid == id).FirstOrDefault();
        }


        private bool m_Case_itemExists(string id, long lang, long tindex)
        {
            return db.m_Case_items.Count(e => e.tkeyNo == id && e.tLang == lang && e.tIndex == tindex) > 0;
        }
        private m_Case_items m_Case_itemByNo(string id, long lang, long tindex)
        {
            return db.m_Case_items.Where(e => e.tkeyNo == id && e.tLang == lang && e.tIndex == tindex).FirstOrDefault();
        }

        private async Task<bool> m_Case_mainExistsAsync(long id)
        {
            return await db.m_Case_main.CountAsync(e => e.Tid == id) > 0;
        }
    }
}