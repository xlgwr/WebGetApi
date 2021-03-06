﻿using System;
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
using EFLibEMMS.EMMS;

namespace WebGetApi.Controllers
{
    [RoutePrefix("api/GWDAppealCases")]
    public class m_AppealCasesController : ApiController
    {
        public static Dictionary<long, bool> tmpExit = new Dictionary<long, bool>();
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private EMMSDbContext db = new EMMSDbContext();
        private EFLibForApi.emms.emmsApiDbContext dbGet = new emmsApiDbContext();

        // GET: api/m_AppealCases
        public IQueryable<t_AppealCase> Get()
        {
            return db.t_AppealCase.Take(10);
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
                dbMax = await db.t_AppealCase.MaxAsync(m => m.TGetDis);

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
                m_parameter m_parameterCurr = await dbGet.m_parameter.FindAsync("AppealRecordCurrMax");
                m_parameter m_parameter = await dbGet.m_parameter.FindAsync("AppealRecordMax");
                if (m_parameter == null)
                {
                    m_parameter = new m_parameter();
                    m_parameter.paramkey = "AppealRecordMax";
                    m_parameter.paramvalue = "9999999";
                    m_parameter.paramtype = "2AppealRecord";
                    m_parameter.Remark = "上诉记录，范围最大ID";
                    m_parameter.ClientIP = HttpContext.Current.Request.UserHostAddress;
                    m_parameter.tStatus = 0;
                    m_parameter.updtime = DateTime.Now;
                    dbGet.m_parameter.Add(m_parameter);
                    dbGet.SaveChanges();
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
                    m_parameterCurr.updtime = DateTime.Now;
                    dbGet.m_parameter.Add(m_parameterCurr);
                    dbGet.SaveChanges();
                }
                long.TryParse(m_parameter.paramvalue, out getMaxSetValue);
                long.TryParse(m_parameterCurr.paramvalue, out getMaxSetCurrValue);

                getWebDatas = getMaxSetCurrValue - 10;// await db.t_AppealCase.MaxAsync(m => m.TGetDis);

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
        // POST: api/m_AppealCases
        [ResponseType(typeof(m_AppealCases))]
        public async Task<IHttpActionResult> Post(m_AppealCases m_AppealCases)
        {
            logger.DebugFormat("Post");
            long tmpCurrMax = 1;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                logger.InfoFormat("TDis Count:{0}", tmpExit.Count);
                if (tmpExit.ContainsKey(m_AppealCases.TDis))
                {
                    return Ok();
                }
                else
                {
                    if (tmpExit.Count > 2000)
                    {
                        tmpExit.Clear();
                    }
                    tmpExit.Add(m_AppealCases.TDis, true);
                }

                //m_AppealCases.updtime = DateTime.Now;
                //m_AppealCases.ClientIP = HttpContext.Current.Request.UserHostAddress;

                //保存到正式数据库
                t_AppealCase modelSave = new t_AppealCase();
                #region 附值
                modelSave.addtime = DateTime.Now;
                modelSave.updtime = DateTime.Now;

                modelSave.CaseNo = m_AppealCases.caseNo;
                modelSave.OldCaseNo = m_AppealCases.tkeyNo;
                try
                {
                    if (m_AppealCases.caseDate.IndexOf('/') > 0)
                    {
                        var allDate = m_AppealCases.caseDate.Split('/');
                        var month = int.Parse(allDate[1]);
                        var day = int.Parse(allDate[0]);
                        var Year = int.Parse(allDate[2]);
                        if (month > 12 && day <= 12 && Year > 33)
                        {
                            modelSave.OldDate = new DateTime(Year, day, month);
                        }
                        else
                        {
                            modelSave.OldDate = new DateTime(Year, month, day);
                        }
                    }
                }
                catch (Exception ex)
                {
                    modelSave.Remark = m_AppealCases.caseDate;
                    //logger.Error(ex);
                }
                modelSave.Remark = m_AppealCases.tname;
                modelSave.WebURL = m_AppealCases.Remark;
                modelSave.ReportedIn = m_AppealCases.ReportedIn;
                modelSave.TDis = m_AppealCases.TDis;
                modelSave.TGetDis = m_AppealCases.TGetDis;
                #endregion


                m_parameter m_parameterCurr = await dbGet.m_parameter.FindAsync("AppealRecordCurrMax");
                if (m_parameterCurr != null)
                {
                    long.TryParse(m_parameterCurr.paramvalue, out tmpCurrMax);
                    if (m_AppealCases.TGetDis > tmpCurrMax)
                    {
                        m_parameterCurr.paramvalue = m_AppealCases.TGetDis.ToString();
                        m_parameterCurr.ClientIP = HttpContext.Current.Request.UserHostAddress;
                        m_parameterCurr.updtime = DateTime.Now;
                        await dbGet.SaveChangesAsync();
                    }
                }               


                var tmpexitAs = gwtMainExistsAsync(m_AppealCases.caseNo, m_AppealCases.tLang, m_AppealCases.caseDate, m_AppealCases.TDis, m_AppealCases.tIndex);
                if (tmpexitAs)
                {
                    var getModel = gwtMainModel(m_AppealCases.caseNo, m_AppealCases.tLang, m_AppealCases.caseDate, m_AppealCases.TDis, m_AppealCases.tIndex);

                    getModel.CaseNo = m_AppealCases.caseNo;
                    getModel.OldCaseNo = m_AppealCases.tkeyNo;
                    try
                    {
                        if (m_AppealCases.caseDate.IndexOf('/') > 0)
                        {
                            var allDate = m_AppealCases.caseDate.Split('/');
                            var month = int.Parse(allDate[1]);
                            var day = int.Parse(allDate[0]);
                            var Year = int.Parse(allDate[2]);
                            if (month > 12 && day <= 12 && Year > 33)
                            {
                                getModel.OldDate = new DateTime(Year, day, month);
                            }
                            else
                            {
                                getModel.OldDate = new DateTime(Year, month, day);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        getModel.Remark = m_AppealCases.caseDate;
                        //logger.Error(ex);
                    }
                    getModel.Remark = m_AppealCases.tname;
                    getModel.WebURL = m_AppealCases.Remark;
                    getModel.ReportedIn = m_AppealCases.ReportedIn;
                    getModel.TDis = m_AppealCases.TDis;
                    getModel.TGetDis = m_AppealCases.TGetDis;
                    getModel.updtime = DateTime.Now;

                }
                else
                {
                    db.t_AppealCase.Add(modelSave);
                }              

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return Ok();
            //return CreatedAtRoute("DefaultApi", new { id = m_AppealCases.Tid }, m_AppealCases);

        }
        /// <summary>
        ///         e.caseNo == caseNo && e.caseDate == tdate &&
        /// </summary>
        private bool gwtMainExistsAsync(string caseNo, long tlang, string tdate, long tdis, long index)
        {
            //logger.InfoFormat("Lang:{0},caseNo:{1},tdate:{2}", tlang, caseNo, tdate);
            try
            {
                return db.t_AppealCase.Count(e => e.TDis == tdis) > 0;
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
        private t_AppealCase gwtMainModel(string caseNo, long tlang, string tdate, long tdis, long index)
        {
            try
            {
                //logger.InfoFormat("Lang:{0},caseNo:{1},tdate:{2}", tlang, caseNo, tdate);
                return db.t_AppealCase.Where(e => e.TDis == tdis).FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger.Debug(ex);
                return null;
            }
        }
    }
}
