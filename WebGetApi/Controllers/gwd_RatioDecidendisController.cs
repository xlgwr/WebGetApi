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
    public class gwd_RatioDecidendisController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private emmsApiDbContext db = new emmsApiDbContext();

        // GET: api/gwd_RatioDecidendis
        public IQueryable<gwd_RatioDecidendis> Get()
        {
            return db.gwd_RatioDecidendis.Take(10);
        }
        // POST: api/gwd_RatioDecidendis
        [ResponseType(typeof(gwd_RatioDecidendis))]
        public async Task<IHttpActionResult> Post(gwd_RatioDecidendis gwd_RatioDecidendis)
        {
            logger.DebugFormat("Post");
            long tmpCurrMax = 1;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                gwd_RatioDecidendis.UpdateDate = DateTime.Now;
                gwd_RatioDecidendis.ClientIP = HttpContext.Current.Request.UserHostAddress;

                var tmpexitAs = gwtMainExistsAsync(gwd_RatioDecidendis.caseNo, gwd_RatioDecidendis.tLang, gwd_RatioDecidendis.TDis, gwd_RatioDecidendis.caseDate);
                if (tmpexitAs)
                {
                    var getModel = gwtMainModel(gwd_RatioDecidendis.caseNo, gwd_RatioDecidendis.tLang, gwd_RatioDecidendis.TDis, gwd_RatioDecidendis.caseDate);

                    getModel.ClientIP = gwd_RatioDecidendis.ClientIP;
                    getModel.Remark = gwd_RatioDecidendis.Remark;
                    getModel.thtml = gwd_RatioDecidendis.thtml;
                    getModel.tname = gwd_RatioDecidendis.tname;
                    getModel.tStatus = gwd_RatioDecidendis.tStatus;
                    getModel.ttype = gwd_RatioDecidendis.ttype;
                    getModel.UpdateDate = gwd_RatioDecidendis.UpdateDate;

                }
                else
                {
                    db.gwd_RatioDecidendis.Add(gwd_RatioDecidendis);
                }

                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return Ok();
            //return CreatedAtRoute("DefaultApi", new { id = gwd_RatioDecidendis.Tid }, gwd_RatioDecidendis);

        }
        private bool gwtMainExistsAsync(string caseNo, long tlang, long tdis, string tdate)
        {
            return db.gwd_RatioDecidendis.Count(e => e.tLang == tlang && e.caseNo == caseNo && e.TDis == tdis && e.caseDate == tdate) > 0;
        }
        private gwd_RatioDecidendis gwtMainModel(string caseNo, long tlang, long tdis, string tdate)
        {
            return db.gwd_RatioDecidendis.Where(e => e.tLang == tlang && e.caseNo == caseNo && e.TDis == tdis && e.caseDate == tdate).FirstOrDefault();
        }
    }
}
