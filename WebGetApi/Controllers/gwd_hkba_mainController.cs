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
    [RoutePrefix("api/GWDhkba")]
    public class gwd_hkba_mainController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private emmsApiDbContext db = new emmsApiDbContext();
        // GET: api/gwd_hkba_main
        public IQueryable<gwd_hkba_main> Get()
        {
            return db.gwd_hkba_main.Take(10);
        }

        // POST: api/gwd_hkba_main
        [ResponseType(typeof(gwd_hkba_main))]
        public async Task<IHttpActionResult> Post(gwd_hkba_main gwd_hkba_main)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                gwd_hkba_main.UpdateDate = DateTime.Now;
                gwd_hkba_main.ClientIP = HttpContext.Current.Request.UserHostAddress;

                var tmpexitAs = gwtMainExistsAsync(gwd_hkba_main.Tid, gwd_hkba_main.TIndex);
                if (tmpexitAs)
                {
                    gwd_hkba_main.tStatus = 5;
                    db.Entry(gwd_hkba_main).State = EntityState.Modified;

                }
                else
                {
                    db.gwd_hkba_main.Add(gwd_hkba_main);
                }



                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = gwd_hkba_main.Tid }, gwd_hkba_main);

        }
        private bool gwtMainExistsAsync(string id, int index)
        {
            return db.gwd_hkba_main.Count(e => e.Tid == id && e.TIndex == index) > 0;
        }
    }
}
