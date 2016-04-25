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
    [RoutePrefix("api/GWDhklawsoc")]
    public class gwd_hklawsoc_mainController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private emmsApiDbContext db = new emmsApiDbContext();
        // GET: api/gwd_hklawsoc_main
        public IQueryable<gwd_hklawsoc_main> Get()
        {
            return db.gwd_hklawsoc_main.Take(10);
        }

        // POST: api/gwd_hklawsoc_main
        [ResponseType(typeof(gwd_hklawsoc_main))]
        public async Task<IHttpActionResult> Post(gwd_hklawsoc_main gwd_hklawsoc_main)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                gwd_hklawsoc_main.UpdateDate = DateTime.Now;
                gwd_hklawsoc_main.ClientIP = HttpContext.Current.Request.UserHostAddress;

                var tmpexitAs = gwtMainExistsAsync(gwd_hklawsoc_main.Tid, gwd_hklawsoc_main.TIndex);
                if (tmpexitAs)
                {
                    db.Entry(gwd_hklawsoc_main).State = EntityState.Modified;

                }
                else
                {
                    db.gwd_hklawsoc_main.Add(gwd_hklawsoc_main);
                }



                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = gwd_hklawsoc_main.Tid }, gwd_hklawsoc_main);

        }
        private bool gwtMainExistsAsync(string id, int index)
        {
            return db.gwd_hklawsoc_main.Count(e => e.Tid == id && e.TIndex == index) > 0;
        }
    }
}
