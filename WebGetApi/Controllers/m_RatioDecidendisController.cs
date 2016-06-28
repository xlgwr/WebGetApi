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
    public class m_RatioDecidendisController : ApiController
    {
        public static Dictionary<long, bool> tmpExit = new Dictionary<long, bool>();
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private emmsApiDbContext db = new emmsApiDbContext();

        // GET: api/m_RatioDecidendis
        public IQueryable<m_RatioDecidendis> Get()
        {
            return db.m_RatioDecidendis.Take(10);
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
                m_RatioDecidendis.updtime = DateTime.Now;
                m_RatioDecidendis.ClientIP = HttpContext.Current.Request.UserHostAddress;

                logger.InfoFormat("m_RatioDecidendis TDis Count:{0}", tmpExit.Count);
                if (tmpExit.ContainsKey(m_RatioDecidendis.TDis))
                {                   
                    return Ok();
                }
                else
                {
                    if (tmpExit.Count > 1000)
                    {
                        tmpExit.Clear();
                    }
                    tmpExit.Add(m_RatioDecidendis.TDis, true);
                }

                var tmpexitAs = gwtMainExistsAsync(m_RatioDecidendis.caseNo, m_RatioDecidendis.tLang, m_RatioDecidendis.TDis, m_RatioDecidendis.caseDate);
                if (tmpexitAs)
                {
                    var getModel = gwtMainModel(m_RatioDecidendis.caseNo, m_RatioDecidendis.tLang, m_RatioDecidendis.TDis, m_RatioDecidendis.caseDate);

                    getModel.ClientIP = m_RatioDecidendis.ClientIP;
                    getModel.Remark = m_RatioDecidendis.Remark;
                    getModel.thtml = m_RatioDecidendis.thtml;
                    getModel.tname = m_RatioDecidendis.tname;
                    getModel.tStatus = m_RatioDecidendis.tStatus;
                    getModel.ttype = m_RatioDecidendis.ttype;
                    getModel.updtime = m_RatioDecidendis.updtime;

                }
                else
                {
                    db.m_RatioDecidendis.Add(m_RatioDecidendis);
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
            return db.m_RatioDecidendis.Count(e => e.tLang == tlang && e.caseNo == caseNo && e.TDis == tdis && e.caseDate == tdate) > 0;
        }
        private m_RatioDecidendis gwtMainModel(string caseNo, long tlang, long tdis, string tdate)
        {
            return db.m_RatioDecidendis.Where(e => e.tLang == tlang && e.caseNo == caseNo && e.TDis == tdis && e.caseDate == tdate).FirstOrDefault();
        }
    }
}
