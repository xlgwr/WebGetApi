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
    [RoutePrefix("api/GWDAppealCases")]
    public class gwd_AppealCasesController : ApiController
    {
        public static Dictionary<long, bool> tmpExit = new Dictionary<long, bool>();
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private emmsApiDbContext db = new emmsApiDbContext();

        // GET: api/gwd_AppealCases
        public IQueryable<gwd_AppealCases> Get()
        {
            return db.gwd_AppealCases.Take(10);
        }

        // GET: api/gwd_AppealCases/5
        [ResponseType(typeof(gwd_AppealCases))]
        public async Task<IHttpActionResult> Get(string id, string id2, string id3, string id4, string id5, int id6)
        {
            ///FACC2/2015/29/01/2016
            var tid = id.Trim() + "/" + id2.Trim();
            var tDate = id3.Trim() + "/" + id4.Trim() + "/" + id5.Trim();

            gwd_AppealCases gwd_AppealCases = await db.gwd_AppealCases.FindAsync(new object[] { tid, tDate });
            if (gwd_AppealCases == null)
            {
                return NotFound();
            }

            return Ok(gwd_AppealCases);
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
                dbMax = await db.gwd_AppealCases.MaxAsync(m => m.TGetDis);

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
                m_parameter m_parameterCurr = await db.m_parameter.FindAsync("AppealRecordCurrMax");
                m_parameter m_parameter = await db.m_parameter.FindAsync("AppealRecordMax");
                if (m_parameter == null)
                {
                    m_parameter = new m_parameter();
                    m_parameter.paramkey = "AppealRecordMax";
                    m_parameter.paramvalue = "999999";
                    m_parameter.paramtype = "2AppealRecord";
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
                    m_parameterCurr.paramkey = "AppealRecordCurrMax";
                    m_parameterCurr.paramvalue = "1";
                    m_parameterCurr.paramtype = "2AppealRecord";
                    m_parameterCurr.Remark = "上诉记录，当前取得最大ID";
                    m_parameterCurr.ClientIP = HttpContext.Current.Request.UserHostAddress;
                    m_parameterCurr.tStatus = 0;
                    m_parameterCurr.UpdateDate = DateTime.Now;
                    db.m_parameter.Add(m_parameterCurr);
                    db.SaveChanges();
                }
                long.TryParse(m_parameter.paramvalue, out getMaxSetValue);
                long.TryParse(m_parameterCurr.paramvalue, out getMaxSetCurrValue);

                getWebDatas = getMaxSetCurrValue - 10;// await db.gwd_AppealCases.MaxAsync(m => m.TGetDis);

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
        // POST: api/gwd_AppealCases
        [ResponseType(typeof(gwd_AppealCases))]
        public async Task<IHttpActionResult> Post(gwd_AppealCases gwd_AppealCases)
        {
            logger.DebugFormat("Post");
            long tmpCurrMax = 1;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                gwd_AppealCases.UpdateDate = DateTime.Now;
                gwd_AppealCases.ClientIP = HttpContext.Current.Request.UserHostAddress;

                m_parameter m_parameterCurr = await db.m_parameter.FindAsync("AppealRecordCurrMax");
                if (m_parameterCurr != null)
                {
                    long.TryParse(m_parameterCurr.paramvalue, out tmpCurrMax);
                    if (gwd_AppealCases.TGetDis > tmpCurrMax)
                    {
                        m_parameterCurr.paramvalue = gwd_AppealCases.TGetDis.ToString();
                        m_parameterCurr.ClientIP = HttpContext.Current.Request.UserHostAddress;
                        m_parameterCurr.UpdateDate = DateTime.Now;
                    }
                }

                logger.InfoFormat("TDis Count:{0}", tmpExit.Count);
                if (tmpExit.ContainsKey(gwd_AppealCases.TDis))
                {
                    await db.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    if (tmpExit.Count > 1000)
                    {
                        tmpExit.Clear();
                    }
                    tmpExit.Add(gwd_AppealCases.TDis, true);
                }

                var tmpexitAs = gwtMainExistsAsync(gwd_AppealCases.caseNo, gwd_AppealCases.tLang, gwd_AppealCases.caseDate, gwd_AppealCases.TDis, gwd_AppealCases.tIndex);
                if (tmpexitAs)
                {
                    var getModel = gwtMainModel(gwd_AppealCases.caseNo, gwd_AppealCases.tLang, gwd_AppealCases.caseDate, gwd_AppealCases.TDis, gwd_AppealCases.tIndex);

                    getModel.ClientIP = gwd_AppealCases.ClientIP;
                    getModel.Remark = gwd_AppealCases.Remark;
                    getModel.ReportedIn = gwd_AppealCases.ReportedIn;
                    getModel.tname = gwd_AppealCases.tname;
                    getModel.tStatus = gwd_AppealCases.tStatus;
                    getModel.ttype = gwd_AppealCases.ttype;
                    getModel.UpdateDate = gwd_AppealCases.UpdateDate;

                }
                else
                {
                    db.gwd_AppealCases.Add(gwd_AppealCases);
                }

                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return Ok();
            //return CreatedAtRoute("DefaultApi", new { id = gwd_AppealCases.Tid }, gwd_AppealCases);

        }
        /// <summary>
        ///         e.caseNo == caseNo && e.caseDate == tdate &&
        /// </summary>
        private bool gwtMainExistsAsync(string caseNo, long tlang, string tdate, long tdis, long index)
        {
            //logger.InfoFormat("Lang:{0},caseNo:{1},tdate:{2}", tlang, caseNo, tdate);
            try
            {
                return db.gwd_AppealCases.Count(e => e.tLang == tlang && e.TDis == tdis) > 0;
            }
            catch (Exception ex)
            {
                logger.Debug(ex);
                return false;
            }

        }
        /// <summary>
        ///  e.caseNo == caseNo && e.caseDate == tdate &&
        /// </summary>
        /// <param name="caseNo"></param>
        /// <param name="tlang"></param>
        /// <param name="tdate"></param>
        /// <param name="tdis"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private gwd_AppealCases gwtMainModel(string caseNo, long tlang, string tdate, long tdis, long index)
        {
            try
            {

                //logger.InfoFormat("Lang:{0},caseNo:{1},tdate:{2}", tlang, caseNo, tdate);
                return db.gwd_AppealCases.Where(e => e.tLang == tlang && e.TDis == tdis).FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger.Debug(ex);
                return null;
            }
        }
    }
}
