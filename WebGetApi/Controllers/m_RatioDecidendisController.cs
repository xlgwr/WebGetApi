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
using EFLibEMMS.EMMS;

namespace WebGetApi.Controllers
{
    [RoutePrefix("api/GWDAppealCases")]
    public class m_RatioDecidendisController : ApiController
    {
        public static Dictionary<string, bool> tmpExit = new Dictionary<string, bool>();
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private EMMSDbContext db = new EMMSDbContext();
        private EFLibForApi.emms.emmsApiDbContext dbGet = new emmsApiDbContext();

        // GET: api/m_RatioDecidendis
        public IQueryable<t_Judgment> Get()
        {
            return db.t_Judgment.Take(10);
        }
        // POST: api/m_RatioDecidendis
        [ResponseType(typeof(m_RatioDecidendis))]
        public async Task<IHttpActionResult> Post(m_RatioDecidendis m_RatioDecidendis)
        {
            logger.DebugFormat("Post");
            long tmpCurrMax = 1;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                
                logger.InfoFormat("m_RatioDecidendis TDis Count:{0}", tmpExit.Count);
                var tmpKey = m_RatioDecidendis.TDis + "_" + m_RatioDecidendis.tLang;
                if (tmpExit.ContainsKey(tmpKey))
                {
                    return Ok();
                }
                else
                {
                    if (tmpExit.Count > 5000)
                    {
                        tmpExit.Clear();
                    }
                    tmpExit.Add(tmpKey, true);
                }
                //    m_RatioDecidendis.updtime = DateTime.Now;
                //    m_RatioDecidendis.ClientIP = HttpContext.Current.Request.UserHostAddress;

                //保存到正式数据库
                t_Judgment modelSave = new t_Judgment();
                #region 附值
                modelSave.CaseNo = m_RatioDecidendis.caseNo;
                modelSave.Language = m_RatioDecidendis.tLang;

                modelSave.WebURL = m_RatioDecidendis.Remark;
                var tmpCase = gwtCaseModel(modelSave.CaseNo);
                if (tmpCase != null)
                {
                    modelSave.Caseid = tmpCase.Caseid;
                    tmpCase.Judgement = 1;
                }
                try
                {

                    if (m_RatioDecidendis.caseDate.IndexOf('/') > 0)
                    {
                        var allDate = m_RatioDecidendis.caseDate.Split('/');
                        var month = int.Parse(allDate[1]);
                        var day = int.Parse(allDate[0]);
                        var Year = int.Parse(allDate[2]);
                        if (month > 12 && day <= 12 && Year > 33)
                        {
                            modelSave.ResultDate = new DateTime(Year, day, month);
                        }
                        else
                        {
                            modelSave.ResultDate = new DateTime(Year, month, day);
                        }
                    }
                }
                catch (Exception ex)
                {
                    modelSave.Remark = m_RatioDecidendis.caseDate;
                    //logger.Error(ex);
                }
                modelSave.Results = m_RatioDecidendis.thtml;
                modelSave.TDis = m_RatioDecidendis.TDis;
                modelSave.TGetDis = m_RatioDecidendis.TGetDis;
                #endregion

                var tmpexitAs = gwtMainExistsAsync(m_RatioDecidendis.caseNo, m_RatioDecidendis.tLang, m_RatioDecidendis.TDis, m_RatioDecidendis.caseDate);
                if (tmpexitAs)
                {
                    var getModel = gwtMainModel(m_RatioDecidendis.caseNo, m_RatioDecidendis.tLang, m_RatioDecidendis.TDis, m_RatioDecidendis.caseDate);

                    getModel.CaseNo = m_RatioDecidendis.caseNo;
                    getModel.Language = m_RatioDecidendis.tLang;

                    getModel.Caseid = modelSave.Caseid;
                    getModel.WebURL = modelSave.WebURL;
                    try
                    {
                        if (m_RatioDecidendis.caseDate.IndexOf('/') > 0)
                        {
                            var allDate = m_RatioDecidendis.caseDate.Split('/');
                            var month = int.Parse(allDate[1]);
                            var day = int.Parse(allDate[0]);
                            var Year = int.Parse(allDate[2]);
                            if (month > 12 && day <= 12 && Year > 33)
                            {
                                getModel.ResultDate = new DateTime(Year, day, month);
                            }
                            else 
                            {
                                getModel.ResultDate = new DateTime(Year, month, day);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        getModel.Remark = m_RatioDecidendis.caseDate;
                        //logger.Error(ex);
                    }
                    getModel.Results = m_RatioDecidendis.thtml;
                    getModel.TDis = m_RatioDecidendis.TDis;
                    getModel.TGetDis = m_RatioDecidendis.TGetDis;

                }
                else
                {
                    db.t_Judgment.Add(modelSave);
                }

                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return Ok();
            //return CreatedAtRoute("DefaultApi", new { id = m_RatioDecidendis.Tid }, m_RatioDecidendis);

        }
        private bool gwtMainExistsAsync(string caseNo, long tlang, long tdis, string tdate)
        {
            return db.t_Judgment.Count(e => e.Language == tlang && e.TDis == tdis) > 0;
        }
        private t_Judgment gwtMainModel(string caseNo, long tlang, long tdis, string tdate)
        {
            return db.t_Judgment.Where(e => e.Language == tlang && e.TDis == tdis).FirstOrDefault();
        }
        private t_Case gwtCaseModel(string caseNo)
        {
            return db.t_Case.Where(e => e.CaseNo == caseNo && e.Judgement != 1).FirstOrDefault();
        }
    }
}
