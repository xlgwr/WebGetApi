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

    [RoutePrefix("api/GWDCompaniesRegistry")]
    public class m_CompaniesRegistry_mainController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private emmsApiDbContext db = new emmsApiDbContext();

        // GET: api/m_CompaniesRegistry_main
        public IQueryable<m_CompaniesRegistry_main> Getm_CompaniesRegistry_main()
        {
            return db.m_CompaniesRegistry_main.Take(10);
        }

        // GET: api/m_CompaniesRegistry_main/5
        [ResponseType(typeof(m_CompaniesRegistry_main))]
        public async Task<IHttpActionResult> Getm_CompaniesRegistry_main(string id)
        {
            m_CompaniesRegistry_main m_CompaniesRegistry_main = await db.m_CompaniesRegistry_main.FindAsync(id);
            if (m_CompaniesRegistry_main == null)
            {
                return NotFound();
            }

            return Ok(m_CompaniesRegistry_main);
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
                var tmpkey = "CompaniesRegistryCurrMax" + id;
                m_parameter m_parameterCurr = await db.m_parameter.FindAsync(tmpkey);

                if (m_parameterCurr == null)
                {
                    m_parameterCurr = new m_parameter();
                    m_parameterCurr.paramkey = tmpkey;
                    m_parameterCurr.paramvalue = "1";
                    m_parameterCurr.paramtype = "0CompaniesRegistry";
                    m_parameterCurr.Remark = "公司注册处，当前取得最大ID,0:英文,1:繁体,2:简体.0:US,en,1:HK,zh,2:CN,zh";
                    m_parameterCurr.ClientIP = HttpContext.Current.Request.UserHostAddress;
                    m_parameterCurr.tStatus = 0;
                    m_parameterCurr.updtime = DateTime.Now;
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
        [HttpPost]
        // POST: api/m_CompaniesRegistry_DisOrders
        [ResponseType(typeof(bool))]
        [Route("m_CompaniesRegistry_DisOrders")]
        public async Task<IHttpActionResult> m_CompaniesRegistry_DisOrders(ICollection<m_CompaniesRegistry_DisOrders> m_CompaniesRegistry_DisOrders)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                foreach (var item in m_CompaniesRegistry_DisOrders)
                {
                    item.updtime = DateTime.Now;
                    item.ClientIP = HttpContext.Current.Request.UserHostAddress;

                    if (m_CompaniesRegistry_DisOrdersExists(item.RecordID))
                    {
                        db.Entry(item).State = EntityState.Modified;
                    }
                    else
                    {
                        db.m_CompaniesRegistry_DisOrders.Add(item);
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

        // POST: api/m_CompaniesRegistry_main
        [ResponseType(typeof(m_CompaniesRegistry_main))]
        public async Task<IHttpActionResult> Postm_CompaniesRegistry_main(m_CompaniesRegistry_main m_CompaniesRegistry_main)
        {
            long getMaxSetCurrValue = 1;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var tmpkeyParam = "CompaniesRegistryCurrMax" + m_CompaniesRegistry_main.tLang;
                m_parameter m_parameterCurr = await db.m_parameter.FindAsync(tmpkeyParam);

                if (m_parameterCurr != null)
                {
                    long.TryParse(m_parameterCurr.paramvalue, out getMaxSetCurrValue);
                }

                m_CompaniesRegistry_main.updtime = DateTime.Now;
                m_CompaniesRegistry_main.ClientIP = HttpContext.Current.Request.UserHostAddress;

                if (m_CompaniesRegistry_main.m_CompaniesRegistry_items != null)
                {

                    foreach (var item in m_CompaniesRegistry_main.m_CompaniesRegistry_items)
                    {
                        item.htmlID = m_CompaniesRegistry_main.Tid;
                        item.updtime = DateTime.Now;
                        item.ClientIP = HttpContext.Current.Request.UserHostAddress;
                    }
                    foreach (var item in m_CompaniesRegistry_main.m_CompaniesRegistry_itemsChange)
                    {
                        item.htmlID = m_CompaniesRegistry_main.Tid;
                        item.updtime = DateTime.Now;
                        item.ClientIP = HttpContext.Current.Request.UserHostAddress;
                    }

                    if (m_CompaniesRegistry_main.m_CompaniesRegistry_items.Count > 0)
                    {
                        var tmpfirst = m_CompaniesRegistry_main.m_CompaniesRegistry_items.First();
                        var tmpexit = m_CompaniesRegistry_itemsExists(tmpfirst.tkeyNo, tmpfirst.tLang);
                        if (tmpexit)
                        {
                            foreach (var item in m_CompaniesRegistry_main.m_CompaniesRegistry_items)
                            {
                                if (!string.IsNullOrEmpty(item.CompanyName) || !string.IsNullOrEmpty(item.CompanyNameZH))
                                {
                                    var getItem = m_CompaniesRegistry_itemsExistsByTkeyNo(item.tkeyNo, item.tLang);
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
                                        getItem.updtime = DateTime.Now;

                                        //change main
                                        var getMain = m_CompaniesRegistry_mainById(getItem.htmlID);
                                        if (getMain != null)
                                        {
                                            getMain.thtml = m_CompaniesRegistry_main.thtml;
                                            getMain.tLang = m_CompaniesRegistry_main.tLang;
                                            getMain.ClientIP = m_CompaniesRegistry_main.ClientIP;
                                            getMain.Remark = m_CompaniesRegistry_main.Remark;
                                            getMain.tname = m_CompaniesRegistry_main.tname;
                                            getMain.tStatus = m_CompaniesRegistry_main.tStatus;
                                            getMain.ttype = m_CompaniesRegistry_main.ttype;
                                            getMain.updtime = DateTime.Now;

                                        }
                                    }
                                    //end fi
                                }
                            }

                            //for change
                            foreach (var item in m_CompaniesRegistry_main.m_CompaniesRegistry_itemsChange)
                            {
                                if (!string.IsNullOrEmpty(item.CompanyName) || !string.IsNullOrEmpty(item.CompanyNameZH))
                                {
                                    var getItemChange = m_CompaniesRegistry_itemsChangeExistsByTkeyNo(item.tkeyNo, item.tLang, item.tIndex);
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
                                        getItemChange.updtime = DateTime.Now;
                                    }
                                }
                            }
                            /////////////////////////////////////end

                        }
                        else
                        {
                            db.m_CompaniesRegistry_main.Add(m_CompaniesRegistry_main);
                        }

                        if (m_parameterCurr != null)
                        {

                            long tmpGetSave = 1;
                            long.TryParse(m_CompaniesRegistry_main.m_CompaniesRegistry_items.First().tkeyNo, out tmpGetSave);

                            if (tmpGetSave > getMaxSetCurrValue)
                            {
                                m_parameterCurr.paramvalue = tmpGetSave.ToString();
                                m_parameterCurr.ClientIP = HttpContext.Current.Request.UserHostAddress;
                                m_parameterCurr.updtime = DateTime.Now;
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

            return Ok();
            //return CreatedAtRoute("DefaultApi", new { id = m_CompaniesRegistry_main.Tid }, m_CompaniesRegistry_main);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool m_CompaniesRegistry_mainExists(long id)
        {
            return db.m_CompaniesRegistry_main.Count(e => e.Tid == id) > 0;
        }
        private m_CompaniesRegistry_main m_CompaniesRegistry_mainById(long id)
        {
            return db.m_CompaniesRegistry_main.Where(e => e.Tid == id).FirstOrDefault();
        }

        private bool m_CompaniesRegistry_itemsExists(string id, long lang)
        {
            var item = db.m_CompaniesRegistry_items.Count(e => e.tkeyNo == id && e.tLang == lang) > 0;
            return item;
        }
        private m_CompaniesRegistry_items m_CompaniesRegistry_itemsExistsByTkeyNo(string id, long lang)
        {
            var item = db.m_CompaniesRegistry_items.Where(e => e.tkeyNo == id && e.tLang == lang).FirstOrDefault();
            return item;
        }
        private m_CompaniesRegistry_itemsChange m_CompaniesRegistry_itemsChangeExistsByTkeyNo(string id, long lang, long index)
        {
            var item = db.m_CompaniesRegistry_itemsChange.Where(e => e.tkeyNo == id && e.tLang == lang && e.tIndex == index).FirstOrDefault();
            return item;
        }

        private bool m_CompaniesRegistry_DisOrdersExists(string id)
        {

            return db.m_CompaniesRegistry_DisOrders.Count(e => e.RecordID == id) > 0;
        }
    }
}