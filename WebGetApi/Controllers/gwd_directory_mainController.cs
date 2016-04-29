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
    /// <summary>
    /// 香港特别行政区政府及有关机构电话薄
    /// </summary>
    [RoutePrefix("api/GWDdirectory")]
    public class gwd_directory_mainController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private emmsApiDbContext db = new emmsApiDbContext();
        // GET: api/gwd_directory_main
        public IQueryable<gwd_directory_main> Get()
        {
            return db.gwd_directory_main.Take(10);
        }

        // POST: api/gwd_directory_main
        [ResponseType(typeof(gwd_directory_main))]
        public async Task<IHttpActionResult> Post(gwd_directory_main gwd_directory_main)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                gwd_directory_main.UpdateDate = DateTime.Now;
                gwd_directory_main.ClientIP = HttpContext.Current.Request.UserHostAddress;

                var tmpexitAs = gwtMainExistsAsync(gwd_directory_main.Tid, gwd_directory_main.tclass, gwd_directory_main.TIndex);
                if (tmpexitAs)
                {
                    gwd_directory_main.tStatus = 5;
                    db.Entry(gwd_directory_main).State = EntityState.Modified;

                }
                else
                {
                    db.gwd_directory_main.Add(gwd_directory_main);
                }



                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = gwd_directory_main.Tid }, gwd_directory_main);

        }
        private bool gwtMainExistsAsync(string id, string tclass, int index)
        {
            return db.gwd_directory_main.Count(e => e.Tid == id && e.tclass == tclass && e.TIndex == index) > 0;
        }
    }
}
