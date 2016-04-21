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

                m_parameter m_parameterCurr = await db.m_parameter.FindAsync("ICRISCurrMax");

                if (m_parameterCurr == null)
                {
                    m_parameterCurr = new m_parameter();
                    m_parameterCurr.paramkey = "ICRISCurrMax";
                    m_parameterCurr.paramvalue = "1";
                    m_parameterCurr.paramtype = "0ICRIS";
                    m_parameterCurr.Remark = "公司注册处，当前取得最大ID";
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
        public async Task<IHttpActionResult> Putgwd_ICRIS_main(string id, gwd_ICRIS_main gwd_ICRIS_main)
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
                m_parameter m_parameterCurr = await db.m_parameter.FindAsync("ICRISCurrMax");

                if (m_parameterCurr != null)
                {
                    long.TryParse(m_parameterCurr.paramvalue, out getMaxSetCurrValue);
                }

                gwd_ICRIS_main.UpdateDate = DateTime.Now;
                gwd_ICRIS_main.ClientIP = HttpContext.Current.Request.UserHostAddress;

                if (gwd_ICRIS_main.gwd_ICRIS_items != null)
                {
                    gwd_ICRIS_main.gwd_ICRIS_items.Tid = gwd_ICRIS_main.Tid;
                    gwd_ICRIS_main.gwd_ICRIS_items.UpdateDate = DateTime.Now;
                }

                if (gwd_ICRIS_mainExists(gwd_ICRIS_main.Tid))
                {
                    db.Entry(gwd_ICRIS_main).State = EntityState.Modified;
                    if (!string.IsNullOrEmpty(gwd_ICRIS_main.gwd_ICRIS_items.tcomp))
                    {
                        db.Entry(gwd_ICRIS_main.gwd_ICRIS_items).State = EntityState.Modified;
                    }
                }
                else
                {
                    db.gwd_ICRIS_main.Add(gwd_ICRIS_main);
                }
                if (m_parameterCurr != null)
                {
                    long tmpGetSave = 1;
                    long.TryParse(gwd_ICRIS_main.Tid, out tmpGetSave);
                    if (tmpGetSave > getMaxSetCurrValue)
                    {
                        m_parameterCurr.paramvalue = tmpGetSave.ToString();
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

            return CreatedAtRoute("DefaultApi", new { id = gwd_ICRIS_main.Tid }, gwd_ICRIS_main);
        }

        // DELETE: api/gwd_ICRIS_main/5
        [ResponseType(typeof(gwd_ICRIS_main))]
        public async Task<IHttpActionResult> Deletegwd_ICRIS_main(string id)
        {
            gwd_ICRIS_main gwd_ICRIS_main = await db.gwd_ICRIS_main.FindAsync(id);
            if (gwd_ICRIS_main == null)
            {
                return NotFound();
            }

            db.gwd_ICRIS_main.Remove(gwd_ICRIS_main);
            await db.SaveChangesAsync();

            return Ok(gwd_ICRIS_main);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool gwd_ICRIS_mainExists(string id)
        {
            return db.gwd_ICRIS_main.Count(e => e.Tid == id) > 0;
        }
    }
}