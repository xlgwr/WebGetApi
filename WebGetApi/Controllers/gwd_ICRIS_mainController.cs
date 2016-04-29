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

    [RoutePrefix("api/GWDICRIS")]
    public class gwd_ICRIS_mainController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private emmsApiDbContext db = new emmsApiDbContext();

        // GET: api/gwd_ICRIS_main
        public IQueryable<gwd_ICRIS_main> Getgwd_ICRIS_main()
        {
            return db.gwd_ICRIS_main.Take(10);
        }

        // GET: api/gwd_ICRIS_main/5
        [ResponseType(typeof(gwd_ICRIS_main))]
        public async Task<IHttpActionResult> Getgwd_ICRIS_main(string id)
        {
            gwd_ICRIS_main gwd_ICRIS_main = await db.gwd_ICRIS_main.FindAsync(id);
            if (gwd_ICRIS_main == null)
            {
                return NotFound();
            }

            return Ok(gwd_ICRIS_main);
        }
        // GET: api/GetWebDatas/GetWebDatasMaxName/{ttype}
        [ResponseType(typeof(string))]
        [Route("GetWebDatasMaxName/{id}")]
        public async Task<IHttpActionResult> GetWebDatasMaxAsync(string id)
        {
            long getMaxSetCurrValue = 1;
            try
            {
                logger.Info(id);
                var tmpkey = "ICRISCurrMax" + id;
                m_parameter m_parameterCurr = await db.m_parameter.FindAsync(tmpkey);

                if (m_parameterCurr == null)
                {
                    m_parameterCurr = new m_parameter();
                    m_parameterCurr.paramkey = tmpkey;
                    m_parameterCurr.paramvalue = "1";
                    m_parameterCurr.paramtype = "0ICRIS";
                    m_parameterCurr.Remark = "公司注册处，当前取得最大ID,0:英文,1:繁体,2:简体.0:US,en,1:HK,zh,2:CN,zh";
                    m_parameterCurr.ClientIP = HttpContext.Current.Request.UserHostAddress;
                    m_parameterCurr.tStatus = 0;
                    m_parameterCurr.UpdateDate = DateTime.Now;
                    db.m_parameter.Add(m_parameterCurr);
                    db.SaveChanges();
                }
                long.TryParse(m_parameterCurr.paramvalue, out getMaxSetCurrValue);
                getMaxSetCurrValue -= 10;
                if (getMaxSetCurrValue < 1)
                {
                    getMaxSetCurrValue = 1;
                }
                return Ok((getMaxSetCurrValue).ToString("0000000"));
            }
            catch (Exception)
            {

                throw;
            }


        }

        // PUT: api/gwd_ICRIS_main/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putgwd_ICRIS_main(long id, gwd_ICRIS_main gwd_ICRIS_main)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gwd_ICRIS_main.Tid)
            {
                return BadRequest();
            }

            db.Entry(gwd_ICRIS_main).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gwd_ICRIS_mainExists(id))
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
        [HttpPost]
        // POST: api/gwd_ICRIS_DisOrders
        [ResponseType(typeof(bool))]
        [Route("gwd_ICRIS_DisOrders")]
        public async Task<IHttpActionResult> gwd_ICRIS_DisOrders(ICollection<gwd_ICRIS_DisOrders> gwd_ICRIS_DisOrders)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                foreach (var item in gwd_ICRIS_DisOrders)
                {
                    item.UpdateDate = DateTime.Now;
                    item.ClientIP = HttpContext.Current.Request.UserHostAddress;

                    if (gwd_ICRIS_DisOrdersExists(item.RecordID))
                    {
                        db.Entry(item).State = EntityState.Modified;
                    }
                    else
                    {
                        db.gwd_ICRIS_DisOrders.Add(item);
                    }
                }

                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(true);
        }

        // POST: api/gwd_ICRIS_main
        [ResponseType(typeof(gwd_ICRIS_main))]
        public async Task<IHttpActionResult> Postgwd_ICRIS_main(gwd_ICRIS_main gwd_ICRIS_main)
        {
            long getMaxSetCurrValue = 1;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var tmpkeyParam = "ICRISCurrMax" + gwd_ICRIS_main.tLang;
                m_parameter m_parameterCurr = await db.m_parameter.FindAsync(tmpkeyParam);

                if (m_parameterCurr != null)
                {
                    long.TryParse(m_parameterCurr.paramvalue, out getMaxSetCurrValue);
                }

                gwd_ICRIS_main.UpdateDate = DateTime.Now;
                gwd_ICRIS_main.ClientIP = HttpContext.Current.Request.UserHostAddress;

                if (gwd_ICRIS_main.gwd_ICRIS_items != null)
                {

                    foreach (var item in gwd_ICRIS_main.gwd_ICRIS_items)
                    {
                        item.htmlID = gwd_ICRIS_main.Tid;
                        item.UpdateDate = DateTime.Now;
                        item.ClientIP = HttpContext.Current.Request.UserHostAddress;
                    }
                    foreach (var item in gwd_ICRIS_main.gwd_ICRIS_itemsChange)
                    {
                        item.htmlID = gwd_ICRIS_main.Tid;
                        item.UpdateDate = DateTime.Now;
                        item.ClientIP = HttpContext.Current.Request.UserHostAddress;
                    }

                    if (gwd_ICRIS_main.gwd_ICRIS_items.Count > 0)
                    {
                        var tmpfirst = gwd_ICRIS_main.gwd_ICRIS_items.First();
                        var tmpexit = gwd_ICRIS_itemsExists(tmpfirst.tkeyNo, tmpfirst.tLang);
                        if (tmpexit)
                        {
                            foreach (var item in gwd_ICRIS_main.gwd_ICRIS_items)
                            {
                                if (!string.IsNullOrEmpty(item.CompanyName) || !string.IsNullOrEmpty(item.CompanyNameZH))
                                {
                                    var getItem = gwd_ICRIS_itemsExistsByTkeyNo(item.tkeyNo, item.tLang);
                                    if (getItem != null)
                                    {
                                        //item.Tid = getItem.Tid;
                                        //item.htmlID = getItem.htmlID;
                                        //item.tkeyNo = getItem.tkeyNo;
                                        //item.tLang = getItem.tLang;
                                        //item.tIndex = getItem.tIndex;                                        

                                        //change item
                                        getItem.ChargeState = item.ChargeState;
                                        getItem.CompanyName = item.CompanyName;
                                        getItem.CompanyNameZH = item.CompanyNameZH;
                                        getItem.ClientIP = item.ClientIP;
                                        getItem.CompanyType = item.CompanyType;
                                        getItem.CurrentState = item.CurrentState;
                                        getItem.DisbandDate = item.DisbandDate;
                                        getItem.FoundDate = item.FoundDate;
                                        getItem.Important = item.Important;
                                        getItem.LiquidationMode = item.LiquidationMode;
                                        getItem.Remark = item.Remark;
                                        getItem.tIndex = item.tIndex;
                                        getItem.tname = item.tname;
                                        getItem.tRemarkNow = item.tRemarkNow;
                                        getItem.tSearchRes = item.tSearchRes;
                                        getItem.tStatus = item.tStatus;
                                        getItem.ttype = item.ttype;
                                        getItem.UpdateDate = DateTime.Now;

                                        //change main
                                        var getMain = gwd_ICRIS_mainById(getItem.htmlID);
                                        if (getMain != null)
                                        {
                                            getMain.thtml = gwd_ICRIS_main.thtml;
                                            getMain.tLang = gwd_ICRIS_main.tLang;
                                            getMain.ClientIP = gwd_ICRIS_main.ClientIP;
                                            getMain.Remark = gwd_ICRIS_main.Remark;
                                            getMain.tname = gwd_ICRIS_main.tname;
                                            getMain.tStatus = gwd_ICRIS_main.tStatus;
                                            getMain.ttype = gwd_ICRIS_main.ttype;
                                            getMain.UpdateDate = DateTime.Now;

                                        }
                                    }
                                    //end fi
                                }
                            }

                            //for change
                            foreach (var item in gwd_ICRIS_main.gwd_ICRIS_itemsChange)
                            {
                                if (!string.IsNullOrEmpty(item.CompanyName) || !string.IsNullOrEmpty(item.CompanyNameZH))
                                {
                                    var getItemChange = gwd_ICRIS_itemsChangeExistsByTkeyNo(item.tkeyNo, item.tLang, item.tIndex);
                                    if (getItemChange != null)
                                    {
                                        //item.Tid = getItem.Tid;
                                        //item.htmlID = getItem.htmlID;
                                        //item.tkeyNo = getItem.tkeyNo;
                                        //item.tLang = getItem.tLang;
                                        //item.tIndex = getItem.tIndex;    
                                        getItemChange.ClientIP = item.ClientIP;
                                        getItemChange.CompanyName = item.CompanyName;
                                        getItemChange.CompanyNameZH = item.CompanyNameZH;
                                        getItemChange.EffectiveDate = item.EffectiveDate;
                                        getItemChange.Remark = item.Remark;
                                        getItemChange.tname = item.tname;
                                        getItemChange.ttype = item.ttype;
                                        getItemChange.tStatus = item.tStatus;
                                        getItemChange.UpdateDate = DateTime.Now;
                                    }
                                }
                            }
                            /////////////////////////////////////end

                        }
                        else
                        {
                            db.gwd_ICRIS_main.Add(gwd_ICRIS_main);
                        }

                        if (m_parameterCurr != null)
                        {

                            long tmpGetSave = 1;
                            long.TryParse(gwd_ICRIS_main.gwd_ICRIS_items.First().tkeyNo, out tmpGetSave);

                            if (tmpGetSave > getMaxSetCurrValue)
                            {
                                m_parameterCurr.paramvalue = tmpGetSave.ToString();
                                m_parameterCurr.ClientIP = HttpContext.Current.Request.UserHostAddress;
                                m_parameterCurr.UpdateDate = DateTime.Now;
                            }

                        }
                    }

                }

                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = gwd_ICRIS_main.Tid }, gwd_ICRIS_main);
        }

        // DELETE: api/gwd_ICRIS_main/5
        [ResponseType(typeof(gwd_ICRIS_main))]
        public async Task<IHttpActionResult> Deletegwd_ICRIS_main(string id)
        {
            //gwd_ICRIS_main gwd_ICRIS_main = await db.gwd_ICRIS_main.FindAsync(id);
            //if (gwd_ICRIS_main == null)
            //{
            //    return NotFound();
            //}

            //db.gwd_ICRIS_main.Remove(gwd_ICRIS_main);
            //await db.SaveChangesAsync();
            //gwd_ICRIS_main

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

        private bool gwd_ICRIS_mainExists(long id)
        {
            return db.gwd_ICRIS_main.Count(e => e.Tid == id) > 0;
        }
        private gwd_ICRIS_main gwd_ICRIS_mainById(long id)
        {
            return db.gwd_ICRIS_main.Where(e => e.Tid == id).FirstOrDefault();
        }

        private bool gwd_ICRIS_itemsExists(string id, long lang)
        {
            var item = db.gwd_ICRIS_items.Count(e => e.tkeyNo == id && e.tLang == lang) > 0;
            return item;
        }
        private gwd_ICRIS_items gwd_ICRIS_itemsExistsByTkeyNo(string id, long lang)
        {
            var item = db.gwd_ICRIS_items.Where(e => e.tkeyNo == id && e.tLang == lang).FirstOrDefault();
            return item;
        }
        private gwd_ICRIS_itemsChange gwd_ICRIS_itemsChangeExistsByTkeyNo(string id, long lang, long index)
        {
            var item = db.gwd_ICRIS_itemsChange.Where(e => e.tkeyNo == id && e.tLang == lang && e.tIndex == index).FirstOrDefault();
            return item;
        }

        private bool gwd_ICRIS_DisOrdersExists(string id)
        {

            return db.gwd_ICRIS_DisOrders.Count(e => e.RecordID == id) > 0;
        }
    }
}