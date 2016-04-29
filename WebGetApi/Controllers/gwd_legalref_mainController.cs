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
        public async Task<IHttpActionResult> Get(string id, string id2, string id3, string id4, string id5, int id6)
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

        // GET: api/GetWebDatas/GetWebDatasMaxDBTDis
        [ResponseType(typeof(long))]
        [Route("GetWebDatasMaxTDis")]
        public async Task<IHttpActionResult> GetWebDatasDBMaxAsync()
        {
            long dbMax = 1;
            try
            {
                //最大获取id
                dbMax = await db.gwd_legalref_main.MaxAsync(m => m.TGetDis);

                if (dbMax < 10)
                {
                    dbMax = 1;
                }
                else
                {
                    dbMax -= 10;
                }
            }
            catch (Exception)
            {

                dbMax = 1;
            }

            return Ok(dbMax);
            //////////////
        }
        // GET: api/GetWebDatas/GetWebDatasMaxTDis
        [ResponseType(typeof(long))]
        [Route("GetWebDatasMaxM_parameterTDis")]
        public async Task<IHttpActionResult> GetWebDatasMaxAsync()
        {
            long getWebDatas = 1;
            long getMaxSetValue = 999999;
            long getMaxSetCurrValue = 1;
            try
            {
                m_parameter m_parameterCurr = await db.m_parameter.FindAsync("legalrefCurrMax");
                m_parameter m_parameter = await db.m_parameter.FindAsync("legalrefMax");
                if (m_parameter == null)
                {
                    m_parameter = new m_parameter();
                    m_parameter.paramkey = "legalrefMax";
                    m_parameter.paramvalue = "999999";
                    m_parameter.paramtype = "2legalref";
                    m_parameter.Remark = "上诉记录，范围最大ID";
                    m_parameter.ClientIP = HttpContext.Current.Request.UserHostAddress;
                    m_parameter.tStatus = 0;
                    m_parameter.UpdateDate = DateTime.Now;
                    db.m_parameter.Add(m_parameter);
                    db.SaveChanges();
                }
                if (m_parameterCurr == null)
                {
                    m_parameterCurr = new m_parameter();
                    m_parameterCurr.paramkey = "legalrefCurrMax";
                    m_parameterCurr.paramvalue = "1";
                    m_parameterCurr.paramtype = "2legalref";
                    m_parameterCurr.Remark = "上诉记录，当前取得最大ID";
                    m_parameterCurr.ClientIP = HttpContext.Current.Request.UserHostAddress;
                    m_parameterCurr.tStatus = 0;
                    m_parameterCurr.UpdateDate = DateTime.Now;
                    db.m_parameter.Add(m_parameterCurr);
                    db.SaveChanges();
                }
                long.TryParse(m_parameter.paramvalue, out getMaxSetValue);
                long.TryParse(m_parameterCurr.paramvalue, out getMaxSetCurrValue);

                getWebDatas = getMaxSetCurrValue - 10;// await db.gwd_legalref_main.MaxAsync(m => m.TGetDis);

            }
            catch (Exception ex)
            {
                getWebDatas = 1;
                getMaxSetValue = 999999;
                logger.Error(ex);
            }
            if (getWebDatas > getMaxSetValue || getWebDatas < 1)
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
            long tmpCurrMax = 1;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                gwd_legalref_main.UpdateDate = DateTime.Now;
                gwd_legalref_main.ClientIP = HttpContext.Current.Request.UserHostAddress;

                m_parameter m_parameterCurr = await db.m_parameter.FindAsync("legalrefCurrMax");
                if (m_parameterCurr != null)
                {
                    long.TryParse(m_parameterCurr.paramvalue, out tmpCurrMax);
                }

                var tmpexitAs = gwtMainExistsAsync(gwd_legalref_main.caseNo, gwd_legalref_main.tLang, gwd_legalref_main.Tdate, gwd_legalref_main.TDis, gwd_legalref_main.TIndex);
                if (tmpexitAs)
                {
                    db.Entry(gwd_legalref_main).State = EntityState.Modified;

                }
                else
                {
                    db.gwd_legalref_main.Add(gwd_legalref_main);
                }

                if (m_parameterCurr != null)
                {
                    if (gwd_legalref_main.TGetDis > tmpCurrMax)
                    {
                        m_parameterCurr.paramvalue = gwd_legalref_main.TGetDis.ToString();
                        m_parameterCurr.ClientIP = HttpContext.Current.Request.UserHostAddress;
                        m_parameterCurr.UpdateDate = DateTime.Now;
                    }
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
        private bool gwtMainExistsAsync(string caseNo, long tlang, string tdate, long tdis, int index)
        {
            return db.gwd_legalref_main.Count(e => e.tLang == tlang && e.caseNo == caseNo && e.Tdate == tdate && e.TDis == tdis && e.TIndex == index) > 0;
        }
    }
}
